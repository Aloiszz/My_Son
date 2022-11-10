using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float speed = 1f;
    public float horizontalInput;
    public float verticalInput;
    
    public static PlayerMovement instance;
    void Update()
    {
        rb.AddForce((transform.forward * verticalInput + transform.right * horizontalInput) * speed, ForceMode.Force);
        rb.drag = 5;

    }
    private void Awake()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        } 
    }
}
