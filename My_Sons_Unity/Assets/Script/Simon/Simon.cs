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
        Jouer();
    }

    void Jouer()
    {
        for (int i = 0; i < 4; i++)
        {
            var k = Random.Range(1,4);
            ChosenColor.Add(k);
        }
    }

    private void Update()
    {
        for (int i = 0; i < ChosenColor.Count;i++)
        {
            if (WrittingList[i] != ChosenColor[i])
            {
                Debug.Log("perdu");
                ChosenColor.Clear();
                WrittingList.Clear();
                Jouer();
            }
            else
            {
                if (i == ChosenColor.Count-1)
                {
                    ChosenColor.Clear();
                    WrittingList.Clear();
                    Jouer();
                }
                
            }

        }
    }
}
