using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveVoiture : MonoBehaviour
{
    public float speed = 1;
    public Transform target;

    public static MoveVoiture instance;

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
    
    // Start is called before the first frame update
    void Update()
    {
        //MoveObject();
    }
    

    public void MoveObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }
}
