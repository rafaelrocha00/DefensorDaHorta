using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class EstaticaDeAudio : MonoBehaviour
{
    [SerializeField]AudioClip somParaTocar;
    [SerializeField]AudioSource source;

    public void Tocar()
    {
        Debug.Log("On point");

        if (!source.isPlaying)
        {
            source.clip = somParaTocar;
            source.Play();
        }
    }

    public void Parar()
    {
        source.Stop();
    }

}
