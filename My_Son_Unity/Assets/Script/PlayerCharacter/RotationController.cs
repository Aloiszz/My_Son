using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private float limitX = 75f;
    [SerializeField] private float rotationSpeed = 500f;
    [SerializeField] private Transform head;

    private float rotationX;
    public float inputRotationX;
    public float inputRotationY;
    
    void Update()
    {
        rotationX -= inputRotationX * rotationSpeed * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -limitX, limitX);
        head.localRotation = Quaternion.Euler(rotationX, 0, 0);
        
        transform.localRotation *= Quaternion.Euler(0,inputRotationY * rotationSpeed * Time.deltaTime,0);
    }
}

