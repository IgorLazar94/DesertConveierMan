using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggingTargetInjector : MonoBehaviour
{
    public static RiggingTargetInjector Instance { get; private set; }

    private void Awake()
    {
        MakeSingleton();
    }

    [SerializeField] private Transform headTarget;
    [SerializeField] private Transform rightHandTarget;
    [SerializeField] private Transform leftHandTarget;

    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SetRightHandTargetPos(Vector3 foodPos)
    {
        rightHandTarget.position = foodPos;
    }

    public Transform GetLeftHandTargetPos()
    {
        return leftHandTarget;
    }

    public Transform GetHeadTargetPos()
    {
        return headTarget;
    }
}
