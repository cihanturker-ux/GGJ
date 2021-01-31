using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followHeight = 7f;
    public float followDistence = 6f;
    public float followHeightSpeed = 0.9f;

    private Transform Player;

    private float targetHeight;
    private float currentHeight;
    private float currentRotation;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        RotateXAxis();

    }

    void RotateXAxis()
    {
        float yAxis = Input.GetAxis("Mouse Y");

        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.x -= yAxis;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
