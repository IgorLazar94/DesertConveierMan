using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 winPosition;
    private CameraShake cameraShake;

    private void Start()
    {
        cameraShake = GetComponent<CameraShake>();
        winPosition = new Vector3(0, 1.5f, 3f);
    }

    private void OnEnable()
    {
        GameManager.OnActivateWinCondition += OffsetCamera;
        RightHandController.OnBombExploded += PlayCameraShake;
    }

    private void OnDisable()
    {
        GameManager.OnActivateWinCondition -= OffsetCamera;
        RightHandController.OnBombExploded -= PlayCameraShake;
    }

    private void OffsetCamera()
    {
        transform.DOMove(winPosition, 1f).SetEase(Ease.InOutBack);
        transform.DORotate(new Vector3(0f, 180f, 0f), 1f).SetEase(Ease.InOutBack);
    }

    private void PlayCameraShake()
    {
        cameraShake.ShakeCamera();
    }
}
