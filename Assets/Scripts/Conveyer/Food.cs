using DG.Tweening;
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
    Pineapple,
    Bomb
}

public class Food : MonoBehaviour
{
    [field: SerializeField] public TypeOfFood typeOfFood { get; private set; }
    public bool isTranslatePosition { get; private set; }
    public static Action onFoodClicked;

    [SerializeField] private GameObject arrowSprite;
    private Tween spriteTween;
    private bool isTargetFood = false;
    private bool isInHand = false;

    private void Start()
    {
        arrowSprite.gameObject.SetActive(false);
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

    private void ActivateSprite()
    {
        arrowSprite.gameObject.SetActive(true);
        arrowSprite.transform.DOMoveY(1.5f, 0.25f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void DiactivateSprite()
    {
        arrowSprite.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!isInHand)
        {
            StartCoroutine(ActivateAsTarget());
            onFoodClicked.Invoke();
        }
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
            ActivateSprite();
        }
        else
        {
            isTranslatePosition = false;
            DiactivateSprite();
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
            DiactivateSprite();
        }
    }

    public void PlacedInTheHand()
    {
        isInHand = true;
    }

    public IEnumerator DetonateTheBomb()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Boom");
    }

}
