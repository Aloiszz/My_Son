using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fenetre : MonoBehaviour
{
    
    [Header("Sound")] 
    public AudioSource source;
    public AudioClip voiture;


    public static Fenetre instance;
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
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
