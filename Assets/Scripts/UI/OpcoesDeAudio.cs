using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OpcoesDeAudio : MonoBehaviour
{
    [SerializeField]AudioMixer audioGeral;

    public void MudarVolume(float novoVolume)
    {
        audioGeral.SetFloat("Volume", Mathf.Log10(novoVolume) * 20);
    }
}
