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
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit,100,mask))
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.name == "Simon" && !Simon.instance.enterInSimon)
                {
                    Simon.instance.enterInSimon = true;
                    Simon.instance.Jouer();
                    //Cam.instance.enterTheSimon(true);
                }
                

                if (Simon.instance.canClick)
                {
                    if (hit.transform.name == "Blue")
                    {
                        Simon.instance.WrittingList.Add(1);
                        Blue.instance.OnClicked();
                    }

                    else if (hit.transform.name == "Green")
                    {
                        Simon.instance.WrittingList.Add(2);
                        Green.instance.OnClicked();
                    }
                
                    else if (hit.transform.name == "Yellow")
                    {
                        Simon.instance.WrittingList.Add(3);
                        Yellow.instance.OnClicked();
                    }
                
                    else if (hit.transform.name == "Red")
                    {
                        Simon.instance.WrittingList.Add(4);
                        Red.instance.OnClicked();
                    }
                }
            }
        }
    }
}
