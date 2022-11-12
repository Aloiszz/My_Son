using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveVoiture : MonoBehaviour
{
    public float speed = 6;
    public Transform target;

    public static MoveVoiture instance;
    
    [Header("Sound")] 
    public AudioSource Source;
    public AudioClip Voiture;
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
    void Update()
    {
        //MoveObject();
    }
    

    public void MoveObject()
    {
        transform.DOMove(target.transform.position, 10);
        Source.PlayOneShot(Voiture);
    }
}
