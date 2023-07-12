using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Food> playersFood = new List<Food>();





    public void SetNewFood(Food newFood)
    {
        playersFood.Add(newFood);
    }

}
