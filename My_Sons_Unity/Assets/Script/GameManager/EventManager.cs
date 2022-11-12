using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventManager : MonoBehaviour
{

    public bool isSimonSlow;
    public bool isSimonExcite; 
    public bool isSimonComplique; 
    
    public static EventManager instance;
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

    public void Update()
    {
        if (isSimonExcite)
        {
            SimonExcite();
            isSimonExcite = false;
        }


        if (Simon.instance.tourDeJeuActuel >= 5)
        {
            Simon.instance.tempsEntreCouleurs = 0.6f;
            Simon.instance.TimeToLight = 0.25f;
        }

        if (Simon.instance.tourDeJeuActuel >= 10)
        {
            Simon.instance.tempsEntreCouleurs = 0.45f;
            Simon.instance.TimeToLight = 0.2f;
        }
        if (Simon.instance.tourDeJeuActuel >= 15)
        {
            Simon.instance.tempsEntreCouleurs = 0.2f;
            Simon.instance.TimeToLight = 0.1f;
        }
        if (Simon.instance.tourDeJeuActuel >= 10)
        {
            Simon.instance.tempsEntreCouleurs = 0.1f;
            Simon.instance.TimeToLight = 0.1f;
        }
    }


    public void SimonDevientLent()
    {
        //var memoryTempsEntreCouleurs = Simon.instance.tempsEntreCouleurs;
        //var memoryTimeToLight = Simon.instance.TimeToLight;

        Simon.instance.tempsEntreCouleurs = Random.Range(.5f,3);
        Simon.instance.TimeToLight = Random.Range(1, 4);
    }

    public void SimonExcite()
    {
        StartCoroutine(AfficheColor());
    }

    public float TimeToLight = 0.35f;
    IEnumerator AfficheColor()
    {
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(Red.instance.Color(TimeToLight));
            StartCoroutine(Blue.instance.Color(TimeToLight));
            StartCoroutine(Green.instance.Color(TimeToLight));
            StartCoroutine(Purple.instance.Color(TimeToLight));
            StartCoroutine(Yellow.instance.Color(TimeToLight));
            StartCoroutine(Cyan.instance.Color(TimeToLight));
            yield return new WaitForSeconds(0.7f);
        }
        for (int i = 0; i < 3; i++) 
        {
            StartCoroutine(Red.instance.Color(TimeToLight));
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Blue.instance.Color(TimeToLight));
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Green.instance.Color(TimeToLight));
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Purple.instance.Color(TimeToLight));
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Yellow.instance.Color(TimeToLight));
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Cyan.instance.Color(TimeToLight));
            yield return new WaitForSeconds(0.5f);
        }
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(Red.instance.Color(TimeToLight));
            StartCoroutine(Blue.instance.Color(TimeToLight));
            StartCoroutine(Green.instance.Color(TimeToLight));
            StartCoroutine(Purple.instance.Color(TimeToLight));
            StartCoroutine(Yellow.instance.Color(TimeToLight));
            StartCoroutine(Cyan.instance.Color(TimeToLight));
            yield return new WaitForSeconds(0.7f);
        }

    }


    public void SimonComplique()
    {
        Simon.instance.tourDeJeu = 40;
        Simon.instance.Jouer();
    }
}
