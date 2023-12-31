using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    private bool isRegisteredFirstTouch = false;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        GameManager.OnActivateWinCondition += StartActivateWinPanel;
        GameManager.OnActivateLoseCondition += ActivateLosePanel;
    }

    private void OnDisable()
    {
        GameManager.OnActivateWinCondition -= StartActivateWinPanel;
        GameManager.OnActivateLoseCondition -= ActivateLosePanel;
    }

    private void DiactivateStartPanel()
    {
        startPanel.transform.DOMoveY(0.5f, 1f).OnComplete(() => startPanel.SetActive(false));
        gameplayPanel.SetActive(true);
        Time.timeScale = 1;
    }

    private void StartActivateWinPanel()
    {
        StartCoroutine(ActivateWinPanel());
    }

    private void ActivateLosePanel()
    {
        gameplayPanel.SetActive(false);
        losePanel.SetActive(true);
        losePanel.transform.DOScale(Vector3.one, 0.5f).OnComplete(() => Time.timeScale = 0);
    }

    private IEnumerator ActivateWinPanel()
    {
        yield return new WaitForSeconds(1f);
        gameplayPanel.SetActive(false);
        winPanel.SetActive(true);
        winPanel.transform.DOScale(Vector3.one, 0.5f);
    }

    private void OnMouseDown()
    {
        if (!isRegisteredFirstTouch)
        {
            isRegisteredFirstTouch = true;
            DiactivateStartPanel();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isRegisteredFirstTouch)
        {
            DiactivateStartPanel();
            isRegisteredFirstTouch = true;
        }
    }
}
