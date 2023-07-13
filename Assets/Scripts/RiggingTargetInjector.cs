using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggingTargetInjector : MonoBehaviour
{
    public static RiggingTargetInjector Instance { get; private set; }
    [SerializeField] private RightHandController rightHand;

    private void Awake()
    {
        AddInjectorStaticLink();
    }

    [SerializeField] private Transform headTarget;
    [SerializeField] private Transform rightHandTarget;
    [SerializeField] private Transform leftHandTarget;

    private void AddInjectorStaticLink()
    {
            Instance = this;
    }

    public void SetRightHandTargetPos(Vector3 foodPos)
    {
        if (!rightHand.CheckISBusyHand())
        {
            rightHandTarget.position = foodPos;
        }
    }

    public void SetLeftHandTargetPos(Vector3 newPos)
    {
         leftHandTarget.position = newPos;
    }

    //public Transform GetHeadTargetPos()
    //{
    //    return headTarget;
    //}
}
