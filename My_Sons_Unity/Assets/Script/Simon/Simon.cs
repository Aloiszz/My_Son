using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Simon : MonoBehaviour
{
    
     [Header("List")]
    public List<int> colorList;
    public List<int> ChosenColor;
    public List<int> WrittingList;

    [Header("Regles")]
    public int tourDeJeu = 4;
    public int tourDeJeuActuel;
    public int NombreDeGameActuel = 0;
    public int NombreDeGamePourExit = 3;

    
    [Header("Timing")]
    public float tempsEntreCouleurs;
    public float TimeToLight;
    

    public BoxCollider coll;

    [Header("evenemeent")] 
    public bool enterInSimon;
    public bool canClick;
    public bool canSpace;
    
    
    [Header("Sound")] 
    public AudioSource source;

    public AudioClip clipBlue;
    public AudioClip clipGreen;
    public AudioClip clipYellow;
    public AudioClip clipRed;
    public AudioClip clipCyan;
    public AudioClip clipPurple;
    public AudioClip clipPetageDeCable;
    

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
        Jouer();
        Simon.instance.enterInSimon = true;
        Cam.instance.enterTheSimon(true);
        EventManager.instance.StopAllCoroutines();
        
    }
    
    private void Update()
    {
        if (NombreDeGameActuel > NombreDeGamePourExit)
        {
            CanvasManager.instance.SpaceUiVisible(true);
            canSpace = true;
        }
        else
        {
            if (!enterInSimon)
            {
                canSpace = true;
            }
            else
            {
                canSpace = false;
            }
        }

        if (enterInSimon)
        {
            coll.size = new Vector3(0.55f,0.08799999f,0.48f);
            coll.center = new Vector3(0, 0, 0);
        }
        else
        {
            coll.size = new Vector3(0.55f,1f,0.48f);
            coll.center = new Vector3(0, 0.3f, 0);
        }

        GameVerification();
    }
    

    public void Jouer()
    {
        for (int i = 0; i < tourDeJeu; i++)
        {
            var k = Random.Range(1,7);
            ChosenColor.Add(k);
            if (EventManager.instance.isSimonSlow)
            {
                EventManager.instance.SimonDevientLent(true);
            }
            Debug.Log("ici");
        }
        NombreDeGameActuel++;
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
                StartCoroutine(Blue.instance.Color(TimeToLight));
                source.PlayOneShot(clipBlue,0.5f);  
            }
            else if (i == 2) // Green
            {
                StartCoroutine(Green.instance.Color(TimeToLight));
                source.PlayOneShot(clipGreen,0.5f);  
            }
            else if (i == 3) // Yellow
            {
                StartCoroutine(Yellow.instance.Color(TimeToLight));
                source.PlayOneShot(clipYellow,0.5f);  
            }
            else if (i == 4)//Red
            {
                StartCoroutine(Red.instance.Color(TimeToLight));
                source.pitch = 0.2f;
                source.PlayOneShot(clipRed,0.5f);  
                source.pitch = 1f;
            }
            else if (i == 5)//Cyan
            {
                StartCoroutine(Cyan.instance.Color(TimeToLight));
                source.PlayOneShot(clipCyan,0.5f);  
            }
            else if (i == 6)//Purple
            {
                StartCoroutine(Purple.instance.Color(TimeToLight));
                source.PlayOneShot(clipPurple,0.5f);  
            }
            tourDeJeuActuel++;
            yield return new WaitForSeconds(tempsEntreCouleurs);
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
                tourDeJeuActuel = 0;
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
