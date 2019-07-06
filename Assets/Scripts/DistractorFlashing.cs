using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DistractorFlashing : MonoBehaviour
{

    public Material normalMaterial;
    public Material flashingMaterial;
    public float frequency;
    private float _period;

    void OnEnable()
    {
        _period = 1 / frequency; //ms
        StartCoroutine(StartFlashing());
    }

    IEnumerator StartFlashing()
    {
        yield return new WaitForSeconds(Random.Range(0.0f, 0.5f));
        while (true)
        {
            yield return StartCoroutine(FlashOff());
            yield return StartCoroutine(FlashOn());
        }
    }

    IEnumerator FlashOff()
    {
        GetComponent<Renderer>().material = normalMaterial;
        yield return new WaitForSeconds(_period);
    }

    IEnumerator FlashOn()
    {
        GetComponent<Renderer>().material = flashingMaterial;
        //m_Renderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        yield return new WaitForSeconds(_period);
    }
}
