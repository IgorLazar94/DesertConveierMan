using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandController : MonoBehaviour
{
    public static Action fruitOnHand;
    private bool isBusyHand = false;

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
        fruitOnHand.Invoke();
    }

    public bool CheckISBusyHand()
    {
        return isBusyHand;
    }
}
