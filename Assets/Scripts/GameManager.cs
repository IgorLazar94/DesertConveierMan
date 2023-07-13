using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private TypeOfFood levelTask;
    private int countOfFoodTask;

    public static Action OnActivateWinCondition;
    public static Action OnActivateLoseCondition;

    private void Awake()
    {
        AddStaticLinkToGM();
        levelTask = GetRandomLevelTask<TypeOfFood>();
        countOfFoodTask = GetRandomCountOfFood();
    }

    private TypeOfFood GetRandomLevelTask<TypeOfFood>() where TypeOfFood : Enum
    {
        Array values = Enum.GetValues(typeof(TypeOfFood));
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);

        int lastIndex = values.Length - 1;
        TypeOfFood randomFood;

        do
        {
            randomFood = (TypeOfFood)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        } while (randomFood.Equals(Enum.GetValues(typeof(TypeOfFood)).GetValue(lastIndex)));
        return randomFood;
    }

    private int GetRandomCountOfFood()
    {
        return UnityEngine.Random.Range(1, 6);
    }

    private void AddStaticLinkToGM()
    {
            Instance = this;
    }

    public TypeOfFood GetLevelTask()
    {
        return levelTask;
    }

    public int GetCountOfFood()
    {
        return countOfFoodTask;
    }

    public void RestartScene()
    {
        var thisScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisScene);
    }

}
