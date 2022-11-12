using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;

    
    
    public static Raycast instance;
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
        cam = Camera.main;
    }

    private RaycastHit hit;
    void Update()
    {
        
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position,             
            Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            

            if (Physics.Raycast(ray,out hit,100,mask))
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.name == "Simon" && !Simon.instance.enterInSimon)
                {
                    Simon.instance.enterInSimon = true;
                    Cam.instance.enterTheSimon(true);
                    EventManager.instance.StopAllCoroutines();
                    MinEmissive();
                    StartCoroutine(WaitToPlay());
                }
                RaycastSimon();
                RaycastFenetre();
                RaycastPorte();
            }
        }
    }


    void RaycastSimon()
    {
        if (Simon.instance.canClick)
        {
            if (hit.transform.name == "Btn_Blue")
            {
                Simon.instance.WrittingList.Add(1);
                Blue.instance.OnClicked();
            }

            else if (hit.transform.name == "Btn_Green")
            {
                Simon.instance.WrittingList.Add(2);
                Green.instance.OnClicked();
            }
                
            else if (hit.transform.name == "Btn_Yellow")
            {
                Simon.instance.WrittingList.Add(3);
                Yellow.instance.OnClicked();
            }
                
            else if (hit.transform.name == "Btn_Red")
            {
                Simon.instance.WrittingList.Add(4);
                Red.instance.OnClicked();
            }
            else if (hit.transform.name == "Btn_Cyan")
            {
                Simon.instance.WrittingList.Add(5);
                Cyan.instance.OnClicked();
            }
            else if (hit.transform.name == "Btn_Purple")
            {
                Simon.instance.WrittingList.Add(6);
                Purple.instance.OnClicked();
            }
        }
    }

    void RaycastFenetre()
    {
        if (hit.transform.name == "Fenetre")
        {
            Cam.instance.enterTheWindow(true);
        }
    }

    void RaycastPorte()
    {
        if (hit.transform.name == "Porte")
        {
            Cam.instance.TouchingTheDoor(true);
            Porte.instance.touchedDoor = true;
        }
    }

    IEnumerator WaitToPlay()
    {
        yield return new WaitForSeconds(2);
        Simon.instance.Jouer();
    }


    void MinEmissive()
    {
        Cyan.instance.MinEmissive();
        Blue.instance.MinEmissive();
        Red.instance.MinEmissive();
        Yellow.instance.MinEmissive();
        Purple.instance.MinEmissive();
        Green.instance.MinEmissive();
    }
}
