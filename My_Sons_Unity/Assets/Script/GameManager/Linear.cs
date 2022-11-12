using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linear : MonoBehaviour
{

    [Header("Bool")] 
    public bool isPorteVisible;
    public bool isFenetreVisible;
    
    
    [Header("Event principaux")] 
    public GameObject Porte;
    public GameObject Fenetre;
    
    
    public static Linear instance;
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
        Fenetre.SetActive(false);
    }


    private void Update()
    {
        if (isFenetreVisible)
        {
            Fenetre.SetActive(true);
        }
        else
        {
            Fenetre.SetActive(false);
        }
    }
}
