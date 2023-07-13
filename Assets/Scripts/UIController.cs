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

    private bool isRegisteredFirstTouch = false;

    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void OnEnable()
    {
        GameManager.OnActivateWinCondition += StartActivateWinPanel;
    }

    private void OnDisable()
    {
        GameManager.OnActivateWinCondition -= StartActivateWinPanel;
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

    //private void Update()
    //{
    //    if (!isRegisteredFirstTouch && Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            isRegisteredFirstTouch = true;
    //            DiactivateStartPanel();
    //        }
    //    }
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isRegisteredFirstTouch)
        {
            DiactivateStartPanel();
            isRegisteredFirstTouch = true;
        }
    }
}
