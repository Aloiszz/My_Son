using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poignée : MonoBehaviour
{
    public AudioSource audioSource;

    public static Poignée instance;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        audioSource.Play();
    }
}
