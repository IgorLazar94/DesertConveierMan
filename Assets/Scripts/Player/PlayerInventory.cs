using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerUIPanelControl playerUIPanel;
    private TypeOfFood levelTask;
    private int lastFoodToVictory;

    private void Start()
    {
        levelTask = GameManager.Instance.GetLevelTask();
        lastFoodToVictory = GameManager.Instance.GetCountOfFood();
        playerUIPanel = gameObject.GetComponentInChildren<PlayerUIPanelControl>();
    }



    public void SetNewFood(Food newFood)
    {
        if ((int)levelTask == (int)newFood.typeOfFood)
        {
            lastFoodToVictory--;
            playerUIPanel.SetTaskText(lastFoodToVictory);
            CheckWinCondition();
        }
    }

    private void CheckWinCondition()
    {
        if (lastFoodToVictory <= 0)
        {
            //GameManager.OnActivateWinCondition.Invoke();
            Debug.Log("Win");
        }
    }
}