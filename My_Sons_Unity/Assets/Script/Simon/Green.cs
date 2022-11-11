using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Green : MonoBehaviour
{
    public GameObject StartPos;
    public GameObject EndPos;
    
    public Material color;
    
    public static Green instance;
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



    public void OnClicked()
    {
        gameObject.transform.DOMove(new Vector3(EndPos.transform.position.x, EndPos.transform.position.y, EndPos.transform.position.z), 0.2f).OnComplete(()=>ComeBack());
        StartCoroutine(Color());
    }
    IEnumerator Color()
    {
        color.SetVector("_EmissionColor", new Vector4(0,191,6) * 0.5f);
        yield return new WaitForSeconds(0.2f);
        color.SetVector("_EmissionColor", new Vector4(0,191,4) * 0.05f);
    }


    void ComeBack()
    {
        gameObject.transform.DOMove(new Vector3(StartPos.transform.position.x, StartPos.transform.position.y, StartPos.transform.position.z), 0.2f);
    }
}
