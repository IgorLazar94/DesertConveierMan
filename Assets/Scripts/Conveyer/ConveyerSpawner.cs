using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject conveyerPrefab;
    [SerializeField] private Transform spawnPoint;
    private float partsSpeed = 5f;

    private void Start()
    {
        StartCoroutine(SpawnConveyerPart());
    }

    private IEnumerator SpawnConveyerPart()
    {
        while (true)
        {
            var conveyer = Instantiate(conveyerPrefab, spawnPoint.position, conveyerPrefab.transform.rotation);
            var x = conveyer.gameObject.GetComponent<ConveyerPartController>();
            x.SetSpeed(partsSpeed);
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Spawn");
        }

    }
}
