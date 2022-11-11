using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;

public class Cam : MonoBehaviour
{
    
    [Header("-------------" +
            "Camera Disponible sur la scene" +
            "-------------")]
    public CinemachineVirtualCamera camPlayer;
    public CinemachineVirtualCamera camSimon;
    
    public CinemachineVirtualCamera camFenetre;
    
    [Header("" +
            "" +
            "-------------" +
            "Raycast Pour Simon" +
            "-------------")]
    public GameObject raycast;
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
        
    }
    
    public void enterTheSimon(bool verif)
    {
        if (verif)
        {
            raycast.transform.DOMove(new Vector3(pos.transform.position.x, pos.transform.position.y, pos.transform.position.z),
                2);
            raycast.transform.DORotate(new Vector3(90, 90, 0),
                2);
            
            camPlayer.Priority = 5;
            camSimon.Priority = 10;
            Cursor.visible = true;

            PlayerMovement.instance.enabled = false;
            RotationController.instance.enabled = false;
            //PlayerInput.instance.enabled = false;
        }

        else
        {
            raycast.transform.DOMove(new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z),
                2);
            raycast.transform.DORotate(new Vector3(90, 90, 0),
                2);
            
            camPlayer.Priority = 10;
            camSimon.Priority = 5;
            
            Cursor.visible = false;
            
            PlayerMovement.instance.enabled = true;
            RotationController.instance.enabled = true;
            //PlayerInput.instance.enabled = true;
        }
        
    }


    public void enterTheWindow(bool verif)
    {
        if (verif)
        {
            camPlayer.Priority = 5;
            camFenetre.Priority = 10;

            PlayerMovement.instance.enabled = false;
            RotationController.instance.enabled = false;
        }
        else
        {
            camPlayer.Priority = 10;
            camFenetre.Priority = 5;

            PlayerMovement.instance.enabled = true;
            RotationController.instance.enabled = true;
        }
    }
}
