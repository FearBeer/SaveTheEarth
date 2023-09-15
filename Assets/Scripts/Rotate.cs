using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float randRotateZ;
    [SerializeField] private float rotationRange = 7;

    private void Awake()
    {
        randRotateZ = Random.Range(-rotationRange, rotationRange);
    }
    void FixedUpdate()
    {
        transform.Rotate(0, 0, randRotateZ);
    }
}
