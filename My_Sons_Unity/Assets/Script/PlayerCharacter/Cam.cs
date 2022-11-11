using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;

public class Cam : MonoBehaviour
{
    public CinemachineVirtualCamera cam;

    public GameObject pos;
    public GameObject head;

    
    public static Cam instance;
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
    
    private void Start()
    {
        /*cam.transform.DOMove(new Vector3(pos.transform.position.x, pos.transform.position.y, pos.transform.position.z),
            2);
        cam.transform.DORotate(new Vector3(90, 90, 0),
            2);


        PlayerMovement.instance.enabled = false;
        RotationController.instance.enabled = false;
        PlayerInput.instance.enabled = false;*/
    }
    
    public void enterTheSimon(bool verif)
    {
        if (verif)
        {
            cam.transform.DOMove(new Vector3(pos.transform.position.x, pos.transform.position.y, pos.transform.position.z),
                2);
            cam.transform.DORotate(new Vector3(90, 90, 0),
                2);


            PlayerMovement.instance.enabled = false;
            RotationController.instance.enabled = false;
            PlayerInput.instance.enabled = false;
        }

        else
        {
            cam.transform.DOMove(new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z),
                2);
            cam.transform.DORotate(new Vector3(90, 90, 0),
                2);


            PlayerMovement.instance.enabled = true;
            RotationController.instance.enabled = true;
            PlayerInput.instance.enabled = true;
        }
        
    }
}
