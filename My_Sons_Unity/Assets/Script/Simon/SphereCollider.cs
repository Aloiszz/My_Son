using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereCollider : MonoBehaviour
{
    public CanvasGroup Crosshair;

    public List<BoxCollider> Collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CrossHair(true);
            foreach (var i in Collider)
            {
                i.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CrossHair(false);
            foreach (var i in Collider)
            {
                i.GetComponent<BoxCollider>().enabled = false;
            }
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
