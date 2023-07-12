using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    TypeOfFood levelTask;

    private void Awake()
    {
        MakeSingleton();
        levelTask = GetRandomLevelTask<TypeOfFood>();
    }





    private TypeOfFood GetRandomLevelTask<TypeOfFood>()
    {
        Array values = Enum.GetValues(typeof(TypeOfFood));
        return (TypeOfFood)values.GetValue(UnityEngine.Random.Range(0, values.Length));
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
        Debug.Log(levelTask + " task");
        return levelTask;
    }
}
