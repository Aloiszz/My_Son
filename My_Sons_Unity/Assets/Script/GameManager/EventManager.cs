using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventManager : MonoBehaviour
{

    public bool isSimonSlow;
    public bool isSimonExcite; 
    public bool isSimonComplique;
    public bool isSimonEND;


    public float TimeForFoot = 1.25f;
    public List<GameObject> piedDuDaron;


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


        foreach (var i in piedDuDaron)
        {
            i.SetActive(false);
        }
    }

    public void Update()
    {
        if (isSimonExcite)
        {
            SimonExcite();
            isSimonExcite = false;
        }

        if (EventManager.instance.isSimonSlow)
        {
            if (Simon.instance.NombreDeGameActuel >= Simon.instance.NombreDeGamePourExit)
            {
                EventManager.instance.SimonDevientLent(false);
                instance.isSimonSlow = false;
            }
        }

        if (isSimonEND)
        {
            SimonEND();
            isSimonEND = false;
        }
        

        if (isSimonComplique)
        {
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
            if (Simon.instance.tourDeJeuActuel == Simon.instance.tourDeJeu-2)
            {
                Simon.instance.tempsEntreCouleurs = 2f;
                Simon.instance.TimeToLight = 0.8f;
            }
            if (Simon.instance.tourDeJeuActuel == Simon.instance.tourDeJeu-1)
            {
                Simon.instance.tempsEntreCouleurs = 1.1f;
                Simon.instance.TimeToLight = 0.4f;
                isSimonComplique = false;
                Linear.instance.isFenetreVisible = true;
            }
        }
    }


    public void SimonDevientLent(bool verif)
    {
        //var memoryTempsEntreCouleurs = Simon.instance.tempsEntreCouleurs;
        //var memoryTimeToLight = Simon.instance.TimeToLight;
        if (verif)
        {
            Simon.instance.tempsEntreCouleurs = Random.Range(.5f,3);
            Simon.instance.TimeToLight = Random.Range(1, 4);
        }
        else
        {
            Simon.instance.tempsEntreCouleurs = 1.1f;
            Simon.instance.TimeToLight = 0.4f;
        }
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


    public void SimonEND()
    {
        StartCoroutine(Walk());
    }

    IEnumerator Walk()
    {
        piedDuDaron[0].SetActive(true);
        yield return new WaitForSeconds(TimeForFoot);
        piedDuDaron[0].SetActive(false);
        piedDuDaron[1].SetActive(true);
        yield return new WaitForSeconds(TimeForFoot);
        piedDuDaron[1].SetActive(false);
        piedDuDaron[2].SetActive(true);
        yield return new WaitForSeconds(TimeForFoot);
        piedDuDaron[2].SetActive(false);
        piedDuDaron[3].SetActive(true);
        yield return new WaitForSeconds(TimeForFoot);
        piedDuDaron[3].SetActive(true);
        piedDuDaron[4].SetActive(true);
        
    }
}
