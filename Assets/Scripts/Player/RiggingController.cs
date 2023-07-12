using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggingController : MonoBehaviour
{
    [SerializeField] Transform rightHandTarget;
    [SerializeField] Transform leftHandTarget;
    [SerializeField] Transform headTarget;

    private Vector3 rightTargetDefaultPos;
    private Vector3 leftTargetDefaultPos;
    private Vector3 headDefaultPos;

    private Vector3 rightHandPassPos;
    private Vector3 leftHandPassPos;

    private void Start()
    {
        rightTargetDefaultPos = rightHandTarget.position;
        leftTargetDefaultPos = leftHandTarget.position;
        headDefaultPos = headTarget.position;
    }

    private void OnEnable()
    {
        RightHandController.foodOnHandEvent += MoveHands;
    }

    private void OnDisable()
    {
        RightHandController.foodOnHandEvent -= MoveHands;
    }

    private void ActivateRiggindAnimation(bool value)
    {

    }

    private void MoveHands()
    {
        rightHandTarget.DOMove(new Vector3(-0.4f, 1, 0), 1f).OnComplete(() => PutFoodInBasket());
        leftHandTarget.DOMove(leftHandTarget.position + new Vector3(0f, 0.2f, 0f), 1f);

    }

    private void PutFoodInBasket()
    {
        rightHandTarget.DOMove(rightTargetDefaultPos, 0.75f);
        leftHandTarget.DOMove(leftTargetDefaultPos, 0.75f);
        RightHandController.foodOffHandEvent.Invoke();
    }
}
