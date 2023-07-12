using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Food> playersFood = new List<Food>();
    private TypeOfFood levelTask;

    private void Start()
    {
        levelTask = GameManager.Instance.GetLevelTask();
    }



    public void SetNewFood(Food newFood)
    {
        if ((int)levelTask == (int)newFood.typeOfFood)
        {
            playersFood.Add(newFood);
        }
    }

}