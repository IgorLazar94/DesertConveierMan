using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandController : MonoBehaviour
{
    public static Action foodOnHandEvent;
    public static Action foodOffHandEvent;

    [SerializeField] private PlayerInventory inventory;
    private bool isBusyHand = false;
    private Food foodInHand;

    private void OnEnable()
    {
        foodOffHandEvent += ClearHands;
    }

    private void OnDisable()
    {
        foodOffHandEvent -= ClearHands;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Food food) && food.isTranslatePosition && !isBusyHand)
        {
            isBusyHand = true;
            ConnectWithFood(food);
        }
    }

    private void ConnectWithFood(Food food)
    {
        food.DiactivateTranslatePosition();
        food.gameObject.transform.localPosition = transform.localPosition - (Vector3.one * 0.01f);
        food.gameObject.transform.SetParent(transform, false);
        foodInHand = food;

        foodOnHandEvent.Invoke();
    }

    public bool CheckISBusyHand()
    {
        return isBusyHand;
    }

    private void ClearHands()
    {
        inventory.SetNewFood(foodInHand);
        Destroy(foodInHand.gameObject);
        isBusyHand = false;
    }
}
