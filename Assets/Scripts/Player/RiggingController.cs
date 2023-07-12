using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggingController : MonoBehaviour
{

    private void OnEnable()
    {
        RightHandController.fruitOnHand += TranslateFruitToBasket;
    }

    private void OnDisable()
    {
        RightHandController.fruitOnHand -= TranslateFruitToBasket;
    }

    private void ActivateRiggindAnimation(bool value)
    {

    }

    private void TranslateFruitToBasket()
    {

    }



}
