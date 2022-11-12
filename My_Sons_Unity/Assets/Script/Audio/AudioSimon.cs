using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSimon : MonoBehaviour
{

    public AudioSource audioSource;
    
    public static AudioSimon instance;

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
    void Start()
    {
        
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
