using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    public CanvasGroup CG_Space;


    
    public static CanvasManager instance;
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


    public void SpaceUiVisible(bool verif)
    {
        if (verif)
        {
            CG_Space.DOFade(1, 2);
        }
        else
        {
            CG_Space.DOFade(0, 2);
        }
    }
}
