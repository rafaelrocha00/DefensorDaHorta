using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoSom : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySom);
    }

    void PlaySom()
    {
        if (C_Audio.audio == null) return;
        C_Audio.audio.Play(clip);
    }
}
