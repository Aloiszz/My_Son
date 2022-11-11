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

    public int tourDeJeu = 4;

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
        //coll = GetComponent<BoxCollider>();
        //Jouer();
    }
    
    private void Update()
    {

        if (enterInSimon)
        {
            coll.size = new Vector3(0.703684f,0.08799999f,0.6f);
            coll.center = new Vector3(0, 0, 0);
        }
        else
        {
            coll.size = new Vector3(0.703684f,1f,0.6f);
            coll.center = new Vector3(0, 0.3f, 0);
        }
        
        GameVerification();
    }
    

    public void Jouer()
    {
        for (int i = 0; i < tourDeJeu; i++)
        {
            var k = Random.Range(1,6);
            ChosenColor.Add(k);
            
        }
        StartCoroutine(AfficheColor());
    }

    IEnumerator AfficheColor()
    {
        canClick = false;
        foreach (var i in ChosenColor)
        {
            //var number = ChosenColor[i];

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
            else if (i == 5)//Cyan
            {
                StartCoroutine(Cyan.instance.Color());
            }
            else if (i == 6)//Purple
            {
                StartCoroutine(Purple.instance.Color());
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
                tourDeJeu = 4;
                StartCoroutine(Perdu());
            }
            else
            {
                if (i == ChosenColor.Count-1) // gagner
                {
                    ChosenColor.Clear();
                    WrittingList.Clear();
                    tourDeJeu++;
                    StartCoroutine(Gagner());
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
        
        yield return new WaitForSeconds(1.5f);
        Jouer();
    }

    IEnumerator Gagner()
    {
        yield return new WaitForSeconds(.7f);
        Jouer();
    }
    
}
