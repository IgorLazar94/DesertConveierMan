using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.LookAt(transform.position + Vector3.up);
    }
}
