using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeDuration = 0.3f;
    private float shakeAmount = 0.4f;
    private float decreaseFactor = 1f;
    private float currentShakeDuration = 0f;

    private void LateUpdate()
    {
        Shaking();
    }

    public void ShakeCamera()
    {
        currentShakeDuration = shakeDuration;

        if (Application.platform == RuntimePlatform.Android)
        {
            Handheld.Vibrate();
        }
    }

    private void Shaking()
    {
        if (currentShakeDuration > 0)
        {
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * shakeAmount;

            currentShakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            currentShakeDuration = 0f;
        }
    }
}
