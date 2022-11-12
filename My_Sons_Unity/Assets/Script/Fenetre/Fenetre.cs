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
    
    private bool verif;
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(6);
        if (!verif)
        {
            verif = true;
            EventManager.instance.isSimonExcite = true;
            EventManager.instance.isSimonComplique = true;
        }
    }
}
