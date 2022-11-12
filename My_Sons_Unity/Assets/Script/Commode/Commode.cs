using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commode : MonoBehaviour
{
    public bool touchedCommode;
    public GameObject CollisionCrosshair;


    [Header("Timing")] 
    public float waitTimeCommode = 2f;
    
    public static Commode instance;
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
        if (touchedCommode)
        {
            //Commode_();
            CollisionCrosshair.SetActive(false);
        }
    }
    
    public void Commode_()
    {
        StartCoroutine(Wait());
        
    }
    
    private bool verif;
    IEnumerator Wait()
    {
        Simon.instance.canSpace = false;
        yield return new WaitForSeconds(waitTimeCommode);
        if (!verif)
        {
            verif = true;
            EventManager.instance.isSimonExcite = true;
            EventManager.instance.isSimonEND = true;
        }
        
        Simon.instance.canSpace = true;
    }



        
}
