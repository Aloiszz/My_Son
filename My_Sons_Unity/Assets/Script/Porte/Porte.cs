using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
            //Poignée.instance.Play();      Poignée qui essaye de se tourner, doit se mettre dès que le joueur clique sur la porte et la caméra zoom dessus
            Move.instance.MoveObject();
            Door();
            CollisionCrosshair.SetActive(false);
        }
    }

    void Door()
    {
        StartCoroutine(Wait());
    }

    private bool verif;
    IEnumerator Wait()
    {
        Simon.instance.canSpace = false;
        yield return new WaitForSeconds(WaitTimePoigner);
        Cam.instance.UnderTheDoor(true);
        
        
        //AudioSimon.instance.Play();      Simon appel le joueur (doit se mettre juste avant que le joueur tourne la tête)
        

        if (!verif)
        {
            verif = true;
            EventManager.instance.isSimonExcite = true;
            EventManager.instance.isSimonComplique = true;
        }

        yield return new WaitForSeconds(WaitTimeUnderTheDoor);

        Cam.instance.UnderTheDoor(false);
        
        yield return new WaitForSeconds(WaitTimeLeaveDoor);

        
        Cam.instance.LeaveDoor();
        
        touchedDoor = false;
        Simon.instance.canSpace = true;
    }
}
