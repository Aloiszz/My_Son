using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linear : MonoBehaviour
{

    [Header("Bool")] 
    public bool isPorteVisible;
    public bool isFenetreVisible;
    public bool isCommodeVisible;
    
    [Header("Event principaux")] 
    public GameObject Porte;
    
    public GameObject Fenetre;
    public GameObject RemplaceFenetre;

    public GameObject Commode;
    public GameObject Biblot;
    
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
        Commode.SetActive(false);
        Biblot.SetActive(false);
    }


    private void Update()
    {
        if (isFenetreVisible)
        {
            Fenetre.SetActive(true);
            RemplaceFenetre.SetActive(false);
        }
        else
        {
            Fenetre.SetActive(false);
        }

        if (isCommodeVisible)
        {
            Commode.SetActive(true);
            Biblot.SetActive(true);
        }
    }
}
