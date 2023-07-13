using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] GameObject basketContent;

    public static Action OnBuskedFilledUp;
    private int counter = 0;
    private float offsetFoodY = 0.5f;

    private void OnEnable()
    {
        OnBuskedFilledUp += AddMoreFood;
    }

    private void OnDisable()
    {
        OnBuskedFilledUp -= AddMoreFood;
    }

    private void FixedUpdate()
    {
        transform.LookAt(transform.position + Vector3.up);
    }

    private void AddMoreFood()
    {
        if (counter == 0)
        {
            basketContent.SetActive(true);
        } else
        {
            basketContent.transform.localPosition += new Vector3(0f, offsetFoodY, 0f);
        }
    }
}
