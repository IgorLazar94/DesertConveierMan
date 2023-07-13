using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfConveyerPart
{
    Empty,
    WithFood
}
public class ConveyerPartController : MonoBehaviour
{
    private ConveyerSpawner conveyerSpawner;
    public TypeOfConveyerPart typeOfConveyerPart;
    private float speed;

    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -12)
        {
            conveyerSpawner.RemoveConveyerPart(this);
        }
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

    public void SetParentLink(ConveyerSpawner spawner)
    {
        conveyerSpawner = spawner;
    }

}
