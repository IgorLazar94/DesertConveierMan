using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Transform playerAddFoodText;
    private PlayerUIPanelControl playerUIPanel;
    private TypeOfFood levelTask;
    private int lastFoodToVictory;


    private void Start()
    {
        levelTask = GameManager.Instance.GetLevelTask();
        lastFoodToVictory = GameManager.Instance.GetCountOfFood();
        playerUIPanel = gameObject.GetComponentInChildren<PlayerUIPanelControl>();
        playerAddFoodText.gameObject.SetActive(false);
    }

    public void SetNewFood(Food newFood)
    {
        if ((int)levelTask == (int)newFood.typeOfFood)
        {
            lastFoodToVictory--;
            Basket.OnBuskedFilledUp.Invoke();
            ShowFoodText();
            playerUIPanel.SetTaskText(lastFoodToVictory);
            CheckWinCondition();
        }
    }

    private void CheckWinCondition()
    {
        if (lastFoodToVictory <= 0)
        {
            GameManager.OnActivateWinCondition.Invoke();
        }
    }

    private void ShowFoodText()
    {
        Vector3 textDeffaultPosition = playerAddFoodText.transform.position;
        playerAddFoodText.gameObject.SetActive(true);
        playerAddFoodText.DOMove(Vector3.up, 1f).OnComplete(() => HideFoodText(textDeffaultPosition));
    }

    private void HideFoodText(Vector3 defPos)
    {
        playerAddFoodText.gameObject.SetActive(false);
        playerAddFoodText.transform.position = defPos;
    }
}