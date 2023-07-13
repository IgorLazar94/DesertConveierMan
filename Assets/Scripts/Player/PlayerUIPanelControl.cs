using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIPanelControl : MonoBehaviour
{
    [SerializeField] private Image taskIcon;
    [SerializeField] private TextMeshProUGUI taskText;
    private int countOfFoodTask;

    private void OnEnable()
    {
        GameManager.OnActivateWinCondition += DiactivatePanel;
    }

    private void OnDisable()
    {
        GameManager.OnActivateWinCondition -= DiactivatePanel;
    }

    private void Awake()
    {
        ChoosePanelParameters();
        taskText.text = countOfFoodTask.ToString();
    }

    private void Start()
    {
        transform.DOScale((Vector3.one * 0.66f), 0.5f);
    }

    private void ChoosePanelParameters()
    {
        taskIcon.sprite = SpriteCollections.Instance.GetTaskSprite();
        countOfFoodTask = GameManager.Instance.GetCountOfFood();
    }

    public void SetTaskText(int value)
    {
        taskText.text = value.ToString();
        taskText.transform.DOScale(Vector3.zero ,0.25f).OnComplete(() => taskText.transform.DOScale(Vector3.one, 0.25f));
    }

    private void DiactivatePanel()
    {
        transform.DOScale(Vector3.zero, 0.25f);
    }
}
