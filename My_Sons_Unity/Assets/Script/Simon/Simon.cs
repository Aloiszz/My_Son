using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Simon : MonoBehaviour
{
    public List<int> colorList;

    public List<int> ChosenColor;
    public List<int> WrittingList;

    public BoxCollider coll;

    [Header("evenemeent")] 
    public bool enterInSimon;
    public bool canClick;

    public static Simon instance;
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

    private void Start()
    {
        coll = GetComponent<BoxCollider>();
        //Jouer();
    }
    
    private void Update()
    {

        if (enterInSimon)
        {
            coll.size = new Vector3(1,1f,1);
            coll.center = new Vector3(0, 0, 0);
        }
        else
        {
            coll.size = new Vector3(1,1.5f,1);
            coll.center = new Vector3(0, 0.3f, 0);
        }
        
        GameVerification();
    }
    

    public void Jouer()
    {
        for (int i = 0; i < 4; i++)
        {
            var k = Random.Range(1,4);
            ChosenColor.Add(k);
            
        }
        StartCoroutine(AfficheColor());
    }

    IEnumerator AfficheColor()
    {
        canClick = false;
        foreach (var i in ChosenColor)
        {
            var number = ChosenColor[i];

            if (i == 1) //blue
            {
                StartCoroutine(Blue.instance.Color());
            }
            else if (i == 2) // Green
            {
                StartCoroutine(Green.instance.Color());
            }
            else if (i == 3) // Yellow
            {
                StartCoroutine(Yellow.instance.Color());
            }
            else if (i == 4)//Red
            {
                StartCoroutine(Red.instance.Color());
            }
            yield return new WaitForSeconds(0.5f);
        }
        canClick = true;
    }

    void GameVerification()
    {
        for (int i = 0; i < ChosenColor.Count;i++)
        {
            if (WrittingList[i] != ChosenColor[i]) // perdu
            {
                Debug.Log("perdu");
                ChosenColor.Clear();
                WrittingList.Clear();
                StartCoroutine(Perdu());
            }
            else
            {
                if (i == ChosenColor.Count-1) // gagner
                {
                    ChosenColor.Clear();
                    WrittingList.Clear();
                    Jouer();
                }
            }

        }
    }

    IEnumerator Perdu()
    {
        StartCoroutine(Yellow.instance.LostGame());
        StartCoroutine(Blue.instance.LostGame());
        StartCoroutine(Red.instance.LostGame());
        StartCoroutine(Green.instance.LostGame());
        
        yield return new WaitForSeconds(1);
        Jouer();
    }
    
}
