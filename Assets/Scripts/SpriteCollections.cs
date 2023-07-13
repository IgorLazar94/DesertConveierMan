using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteCollections : MonoBehaviour
{
    public static SpriteCollections Instance { get; private set; }
 
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite bananaSprite;
    [SerializeField] private Sprite coconutSprite;
    [SerializeField] private Sprite pearSprite;
    [SerializeField] private Sprite pineappleSprite;

    private TypeOfFood levelTask;
    private Sprite taskSprite;

    private void Awake()
    {
        levelTask = GameManager.Instance.GetLevelTask();
        ChooseTaskSprite();
        MakeSingleton();
    }

    private void ChooseTaskSprite()
    {
        switch (levelTask)
        {
            case TypeOfFood.Apple:
                taskSprite = appleSprite;
                break;
            case TypeOfFood.Banana:
                taskSprite = bananaSprite;
                break;
            case TypeOfFood.Coconut:
                taskSprite = coconutSprite;
                break;
            case TypeOfFood.Pear:
                taskSprite = pearSprite;
                break;
            case TypeOfFood.Pineapple:
                taskSprite = pineappleSprite;
                break;
            default:
                Debug.LogWarning("Undefined level task");
                break;
        }
    }

    public Sprite GetTaskSprite()
    {
        return taskSprite;
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
}
