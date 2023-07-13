using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerFxController : MonoBehaviour
{
    [SerializeField] private GameObject FxContainer;
    private ParticleSystem[] playerFx;

    private void Start()
    {
        playerFx = FxContainer.GetComponentsInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        GameManager.OnActivateWinCondition += PlayWinParticles;
    }

    private void OnDisable()
    {
        GameManager.OnActivateWinCondition -= PlayWinParticles;
    }

    private void PlayWinParticles()
    {
        foreach (var fX in playerFx)
        {
            fX.Play();
        }
    }

}
