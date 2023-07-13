using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private TypeOfFood levelTask;
    private int countOfFoodTask;

    private void Awake()
    {
        MakeSingleton();
        levelTask = GetRandomLevelTask<TypeOfFood>();
        countOfFoodTask = GetRandomCountOfFood();
    }

    private TypeOfFood GetRandomLevelTask<TypeOfFood>()
    {
        Array values = Enum.GetValues(typeof(TypeOfFood));
        return (TypeOfFood)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }

    private int GetRandomCountOfFood()
    {
        return UnityEngine.Random.Range(1, 5);
    }

    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public TypeOfFood GetLevelTask()
    {
        return levelTask;
    }

    public int GetCountOfFood()
    {
        return countOfFoodTask;
    }
}
