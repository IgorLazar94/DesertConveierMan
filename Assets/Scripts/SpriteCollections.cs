using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCollections : MonoBehaviour
{
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite bananaSprite;
    [SerializeField] private Sprite coconutSprite;
    [SerializeField] private Sprite pearSprite;
    [SerializeField] private Sprite pineappleSprite;

    private TypeOfFood levelTask;
    private Sprite taskSprite;

    private void Start()
    {
        levelTask = GameManager.Instance.GetLevelTask();
        ChooseTaskSprite();
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
}
