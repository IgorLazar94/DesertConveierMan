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
    private void Start()
    {
        ChoosePanelParameters();
        SetTaskText(countOfFoodTask);
    }

    private void ChoosePanelParameters()
    {
        taskIcon.sprite = SpriteCollections.Instance.GetTaskSprite();
        countOfFoodTask = GameManager.Instance.GetCountOfFood();
    }

    public void SetTaskText(int value)
    {
        taskText.text = value.ToString();
    }

}
