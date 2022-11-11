using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereCollider : MonoBehaviour
{
    public List<BoxCollider> Collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasManager.instance.CrossHair(true);
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
            CanvasManager.instance.CrossHair(false);
            foreach (var i in Collider)
            {
                i.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }



    
}
