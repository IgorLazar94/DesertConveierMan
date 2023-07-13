using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 winPosition;

    private void Start()
    {
        winPosition = new Vector3(0, 1.5f, 3f);
    }
    private void OnEnable()
    {
        GameManager.OnActivateWinCondition += OffsetCamera;
    }

    private void OnDisable()
    {
        GameManager.OnActivateWinCondition -= OffsetCamera;
    }

    private void OffsetCamera()
    {
        transform.DOMove(winPosition, 1f).SetEase(Ease.InOutBack);
        transform.DORotate(new Vector3(0f, 180f, 0f), 1f).SetEase(Ease.InOutBack);
    }
}
