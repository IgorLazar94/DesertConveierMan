using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject conveyerPrefab;
    [SerializeField] private GameObject conveyerPrefabWithFood;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform containerPool;
    private List<ConveyerPartController> conveyersList = new List<ConveyerPartController>();
    private float partsSpeed = 2f;
    private float factorSpeed = 0.2f;
    private float conveyerWidth;
    private float conveyerHeight;

    private void OnEnable()
    {
        GameManager.OnActivateWinCondition += DisableConveyer;
        CountDownTimer.onUpdateSpeedByTime += UpdateConveyerSpeed;
    }

    private void OnDisable()
    {
        GameManager.OnActivateWinCondition -= DisableConveyer;
        CountDownTimer.onUpdateSpeedByTime -= UpdateConveyerSpeed;
    }

    private void Start()
    {
        GetConveyerWidth();
        GetConveyerHeight();
        StartCoroutine(SpawnConveyerPart());
    }

    private IEnumerator SpawnConveyerPart()
    {
        int counter = 0;
        while (true)
        {
            var prefab = ChooseTypeOfConveyerPart(counter);
            InitNewConveier(prefab);
            yield return new WaitForSeconds((conveyerWidth * 2) / partsSpeed);
            counter++;
        }
    }

    private void UpdateConveyerSpeed()
    {
        partsSpeed += factorSpeed;
        foreach (var conveyer in conveyersList)
        {
            conveyer.SetSpeed(partsSpeed);
        }
    }

    private void GetConveyerWidth()
    {
        conveyerWidth = conveyerPrefab.GetComponent<BoxCollider>().size.x;
    }
    private void GetConveyerHeight()
    {
        conveyerHeight = conveyerPrefab.GetComponent<BoxCollider>().size.y;
    }

    private void InitNewConveier(GameObject _conveyerPrefab)
    {
        var conveyerObject = Instantiate(_conveyerPrefab, spawnPoint.position, conveyerPrefab.transform.rotation);
        conveyerObject.transform.parent = containerPool;
        var conveyerPart = conveyerObject.gameObject.GetComponent<ConveyerPartController>();
        conveyerPart.SetParentLink(this);
        conveyersList.Add(conveyerPart);
        if (conveyerPart.typeOfConveyerPart == TypeOfConveyerPart.WithFood)
        {
            InitNewFruit(conveyerPart.gameObject);
        }
        conveyerPart.SetSpeed(partsSpeed);
    }

    private GameObject ChooseTypeOfConveyerPart(int _counter)
    {
        if (_counter % 2 == 0)
        {
            return conveyerPrefab;
        }
        else
        {
            return conveyerPrefabWithFood;
        }
    }

    private void InitNewFruit(GameObject conveyerPart)
    {
        var fruitPrefab = FoodCollections.instance.ChooseRandomFruit();
        float fruitHeight = fruitPrefab.GetComponent<SphereCollider>().radius;
        Vector3 spawnPoint = new Vector3(conveyerPart.transform.position.x,
                                         conveyerPart.transform.position.y + conveyerHeight + (fruitHeight * 2),
                                         conveyerPart.transform.position.z);
        var fruitObject = Instantiate(fruitPrefab, spawnPoint, Quaternion.identity);
        fruitObject.transform.parent = conveyerPart.transform;
    }

    private void DisableConveyer()
    {
        transform.DOScale(Vector3.zero, 0.5f);
    }

    public void RemoveConveyerPart(ConveyerPartController conveyerPart)
    {
        conveyersList.Remove(conveyerPart);
        Destroy(conveyerPart.gameObject);
    }
}
