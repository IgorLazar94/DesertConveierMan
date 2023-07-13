using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollections : MonoBehaviour
{
    public static FoodCollections instance;
    [SerializeField] private List<GameObject> listOfFood = new List<GameObject>();

    private void Awake()
    {
        MakeSingleton();
    }

    public GameObject ChooseRandomFruit()
    {
        var fruit = Random.Range(0, listOfFood.Count);
        return listOfFood[fruit];
    }

    private void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (!ReferenceEquals(instance, this))
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
