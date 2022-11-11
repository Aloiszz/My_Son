using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Blue : MonoBehaviour
{

    public GameObject StartPos;
    public GameObject EndPos;
    
    public Material color;
    
    [Header("Emmissive")]
    public Vector4 vec = new Vector4(0,11,191);
    public float minEmissive = 0.05f;
    public float maxEmissive = 0.5f;
    
    public static Blue instance;
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

    public IEnumerator Color()
    {
        color.SetVector("_EmissionColor", vec * maxEmissive);
        yield return new WaitForSeconds(0.2f);
        color.SetVector("_EmissionColor", vec * minEmissive);
    }

    void ComeBack()
    {
        gameObject.transform.DOMove(new Vector3(StartPos.transform.position.x, StartPos.transform.position.y, StartPos.transform.position.z), 0.2f);
    }

    public IEnumerator LostGame()
    {
        color.SetVector("_EmissionColor", vec * maxEmissive);
        yield return new WaitForSeconds(0.2f);
        color.SetVector("_EmissionColor", vec * minEmissive);
        yield return new WaitForSeconds(0.2f);
        color.SetVector("_EmissionColor", vec * maxEmissive);
        yield return new WaitForSeconds(0.2f);
        color.SetVector("_EmissionColor", vec * minEmissive);
    }
}
