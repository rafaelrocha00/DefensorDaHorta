using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Audio : MonoBehaviour
{
    public static C_Audio audio;
    public AudioSource[] sources;
    [SerializeField] AudioClip construcao;
    [SerializeField] AudioClip dano;
    [SerializeField] AudioClip danoJogador;
    [SerializeField] AudioClip morte;

    [SerializeField] float PitchMin = 0.8f;
    [SerializeField] float PitchMax = 1.2f;
    [SerializeField] float VolumeMin = 0.8f;
    [SerializeField] float VolumeMax = 1f;


    private void Awake()
    {
        if(audio != this && audio != null)
        {
            Destroy(this);

        }
        else
        {
            audio = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Play(AudioClip clip)
    {
        for (int i = 0; i < sources.Length; i++)
        {
            if (!sources[i].isPlaying)
            {
                sources[i].pitch = Random.Range(PitchMin, PitchMax);
                sources[i].volume = Random.Range(VolumeMin, VolumeMax);
                sources[i].clip = clip;
                sources[i].Play();
                return;
            }
        }
    }

    public void PlayAudioConstrucao()
    {
        Play(construcao);
    }

    public void PlayAudioDano()
    {
        Play(dano);
    }

    public void PlayAudioMorte()
    {
        Play(morte);
    }

    public void PlayAudioDanoJogador()
    {
        Play(danoJogador);
    }

}
