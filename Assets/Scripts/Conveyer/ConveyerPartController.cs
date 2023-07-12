using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerPartController : MonoBehaviour
{
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
