using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereCollider : MonoBehaviour
{
    public CanvasGroup Crosshair;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CrossHair(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CrossHair(false);
        }
    }



    void CrossHair(bool verif)
    {
        if (verif)
        {
            Crosshair.DOFade(1, 0.2f);
        }
        else
        {
            Crosshair.DOFade(0, 0.2f);
        }
    }
}
