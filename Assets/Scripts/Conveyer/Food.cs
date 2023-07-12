using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfFood
{
    Apple,
    Banana,
    Coconut,
    Pear,
    PineApple
}
public class Food : MonoBehaviour
{
    [field: SerializeField] public TypeOfFood typeOfFood { get; private set; }
    public static Action onFoodClicked;

    private bool isTargetFood = false;
    public bool isTranslatePosition { get; private set; }

    private void Start()
    {
        isTranslatePosition = false;
    }
    private void OnEnable()
    {
        onFoodClicked += CheckIsActualFood;
    }

    private void OnDisable()
    {
        onFoodClicked -= CheckIsActualFood;
    }

    private void OnMouseDown()
    {
        StartCoroutine(ActivateAsTarget());
        onFoodClicked.Invoke();
    }

    private IEnumerator ActivateAsTarget()
    {
        isTargetFood = true;
        yield return new WaitForSeconds(0.25f);
        isTargetFood = false;
    }

    private void CheckIsActualFood()
    {
        if (isTargetFood)
        {
            isTranslatePosition = true;
        }
        else
        {
            isTranslatePosition = false;
        }
    }

    private void FixedUpdate()
    {
        if (isTranslatePosition)
        {
            RiggingTargetInjector.Instance.SetRightHandTargetPos(transform.position);
        }
    }

    public void DiactivateTranslatePosition()
    {
        if (isTranslatePosition)
        {
            isTranslatePosition = false;
        }
    }

}
