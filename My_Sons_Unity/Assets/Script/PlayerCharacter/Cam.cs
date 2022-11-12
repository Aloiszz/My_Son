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
    [Header("Player")]
    public CinemachineVirtualCamera camPlayer;
    public CinemachineVirtualCamera camLookSimon;
    
    [Header("Simon")]
    public CinemachineVirtualCamera camSimon;
    
    [Header("Fenetre")]
    public CinemachineVirtualCamera camFenetre;
    
    [Header("Porte")]
    public CinemachineVirtualCamera camPorte;
    public CinemachineVirtualCamera camSousPorte;
    public CinemachineVirtualCamera camSousPorteLookSimon;
    
    [Header("Commode")]
    public CinemachineVirtualCamera camCommode;
    
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

            MoveVoiture.instance.MoveObject();
            PlayerMovement.instance.enabled = false;
            RotationController.instance.enabled = false;
        }
        else
        {
            camPlayer.Priority = 10;
            camFenetre.Priority = 5;
        }
    }

    public void TouchingTheDoor(bool verif)
    {
        if (verif)
        {
            camPlayer.Priority = 5;
            camPorte.Priority = 10;

            PlayerMovement.instance.enabled = false;
            RotationController.instance.enabled = false;
        }
        else
        {
            camPlayer.Priority = 10;
            camPorte.Priority = 5;
        }
    }
    
    public void UnderTheDoor(bool verif)
    {
        if (verif)
        {
            camPorte.Priority = 5;
            camSousPorte.Priority = 10;

            PlayerMovement.instance.enabled = false;
            RotationController.instance.enabled = false;
        }
        else
        {
            //Simon.instance.source.PlayOneShot(Simon.instance.clipPetageDeCable, 0.5f);
            camSousPorteLookSimon.Priority = 10;
            camSousPorte.Priority = 5;
        }
    }
    bool verif;
    public void LeaveDoor()
    {
        camPlayer.Priority = 10;
        camSousPorteLookSimon.Priority = 5;
        
        if (!verif)
        {
            PlayerMovement.instance.transform.Rotate(0,180,0);
            verif = true;
        }

        PlayerMovement.instance.enabled = true;
        RotationController.instance.enabled = true;
    }




    public void EnterLaCommode(bool verif)
    {
        if (verif)
        {
            camCommode.Priority = 10;
            camPlayer.Priority = 5;
            
            PlayerMovement.instance.enabled = false;
            RotationController.instance.enabled = false;
        }
        else
        {
            camCommode.Priority = 5;
            camPlayer.Priority = 10;
            
            PlayerMovement.instance.enabled = true;
            RotationController.instance.enabled = true;
        }
    }
}
