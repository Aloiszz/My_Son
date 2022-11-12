using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    public bool touchedDoor;
    
    public GameObject CollisionCrosshair;


    [Header("Timing")]
    public float WaitTimePoigner = 4f;
    public float WaitTimeUnderTheDoor = 4f;
    public float WaitTimeLeaveDoor = 2f;
    
    public static Porte instance;
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
        if (touchedDoor)
        {
            Door();
            CollisionCrosshair.SetActive(false);
        }
    }

    void Door()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        Simon.instance.canSpace = false;
        yield return new WaitForSeconds(WaitTimePoigner);
        Cam.instance.UnderTheDoor(true);
        yield return new WaitForSeconds(WaitTimeUnderTheDoor);
        Cam.instance.UnderTheDoor(false);
        yield return new WaitForSeconds(WaitTimeLeaveDoor);
        Cam.instance.LeaveDoor();
        touchedDoor = false;
        Simon.instance.canSpace = true;
    }
}
