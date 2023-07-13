using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimationRiggingController : MonoBehaviour
{
    [SerializeField] Transform rightHandTarget;
    [SerializeField] Transform leftHandTarget;
    [SerializeField] Transform headTarget;

    private Animator animator;
    private RigBuilder rigBuilder;
    private Vector3 rightTargetDefaultPos;
    private Vector3 leftTargetDefaultPos;
    private Vector3 headDefaultPos;
    //private Vector3 rightHandPassPos;
    //private Vector3 leftHandPassPos;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigBuilder = GetComponent<RigBuilder>();
        rightTargetDefaultPos = rightHandTarget.position;
        leftTargetDefaultPos = leftHandTarget.position;
        headDefaultPos = headTarget.position;
    }

    private void OnEnable()
    {
        RightHandController.foodOnHandEvent += MoveHands;
        GameManager.OnActivateWinCondition += EnableRandomDance;
    }

    private void OnDisable()
    {
        RightHandController.foodOnHandEvent -= MoveHands;
        GameManager.OnActivateWinCondition -= EnableRandomDance;
    }

    private void DiactivateRiggindAnimation()
    {
        rigBuilder.enabled = false;
    }

    private void MoveHands()
    {
        rightHandTarget.DOMove(new Vector3(-0.4f, 1, 0), 1f).OnComplete(() => PutFoodInBasket());
        headTarget.DOMove(new Vector3(-0.4f, 1, 0), 1f);
        leftHandTarget.DOMove(leftHandTarget.position + new Vector3(0f, 0.2f, 0f), 1f);

    }

    private void PutFoodInBasket()
    {
        MoveHandsToDefault();
        RightHandController.foodOffHandEvent.Invoke();
    }

    public void MoveHandsToDefault()
    {
        rightHandTarget.DOMove(rightTargetDefaultPos, 0.75f);
        headTarget.DOMove(headDefaultPos, 0.75f);
        leftHandTarget.DOMove(leftTargetDefaultPos, 0.75f);
    }

    private void EnableRandomDance()
    {
        int typeOfDance = Random.Range(0, 3);
        DiactivateRiggindAnimation();
        animator.SetInteger(AnimParameters.typeOfDance, typeOfDance);
        animator.SetTrigger(AnimParameters.isDance);
    }

    private void EnableRagdoll()
    {
        DiactivateRiggindAnimation();
        animator.enabled = false;

    }

}
