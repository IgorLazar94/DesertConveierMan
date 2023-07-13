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

    private void Awake()
    {
        AddStaticLinkToGM();
        levelTask = GetRandomLevelTask<TypeOfFood>();
        countOfFoodTask = GetRandomCountOfFood();
    }

    private T GetRandomLevelTask<T>()
    {
        Array values = Enum.GetValues(typeof(TypeOfFood));
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }

    private int GetRandomCountOfFood()
    {
        return UnityEngine.Random.Range(1, 5);
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
