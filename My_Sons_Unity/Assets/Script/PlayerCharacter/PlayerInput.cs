using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private RotationController _rotationController;
    [SerializeField] private PlayerMovement _playerMovement;


    public static PlayerInput instance;
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
    
    
    
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rotationController.inputRotationX = Input.GetAxis("Mouse Y");
        _rotationController.inputRotationY = Input.GetAxis("Mouse X");

        _playerMovement.horizontalInput = Input.GetAxis("Horizontal");
        _playerMovement.verticalInput = Input.GetAxis("Vertical");


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Simon.instance.enterInSimon = false;
            Simon.instance.ChosenColor.Clear();
            Simon.instance.WrittingList.Clear();
        }
        
    }
}
