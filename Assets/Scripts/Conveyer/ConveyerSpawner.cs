using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject conveyerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform containerPool;
    private float partsSpeed = 2f;
    private float conveyerWidth;

    private void Start()
    {
        GetConveyerWidth();
        StartCoroutine(SpawnConveyerPart());
    }

    private IEnumerator SpawnConveyerPart()
    {
        while (true)
        {
            var conveyer = Instantiate(conveyerPrefab, spawnPoint.position, conveyerPrefab.transform.rotation);
            conveyer.transform.parent = containerPool;
            var x = conveyer.gameObject.GetComponent<ConveyerPartController>();
            x.SetSpeed(partsSpeed);
            yield return new WaitForSeconds((conveyerWidth * partsSpeed) / 2);
        }

    }

    private void GetConveyerWidth()
    {
        conveyerWidth = conveyerPrefab.GetComponent<BoxCollider>().size.x;
    }
}
