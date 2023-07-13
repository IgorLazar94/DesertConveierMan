using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFoodZone : MonoBehaviour
{
    [SerializeField] private AnimationRiggingController playerRiggControl;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Food food))
        {
            if (food.isTranslatePosition)
            {
                playerRiggControl.MoveHandsToDefault();
                food.DiactivateTranslatePosition();
            }
            food.enabled = false;
        }
    }
}
