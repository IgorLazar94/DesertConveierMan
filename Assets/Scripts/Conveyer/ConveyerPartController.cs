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
    public TypeOfConveyerPart typeOfConveyerPart;
    private float speed;

    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
}
