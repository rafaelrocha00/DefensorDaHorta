using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
public class TransicaoEditor : MonoBehaviour
{
    public Material material;
    [SerializeField] float tempoDisponivelParaTransicao = 1f;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }

    public void IniciarTransicaoFadeIN(GameObject FadeINTOObject, Action FuncaoPosTransicao)
    {
        Time.timeScale = 1;
        StartCoroutine(TransicaoFadeIN(FadeINTOObject, FuncaoPosTransicao));
    }

    public void IniciarTransicaoFadeOUT()
    {
        StartCoroutine(TransicaoFadeOUT());
    }

    public void Start()
    {
        IniciarTransicaoFadeOUT();
    }

    IEnumerator TransicaoFadeIN(GameObject FadeINTOObject, Action FuncaoPosTransicao)
    {
        float contador = 0f;
        float contadorTempo = 0;

        while (contador < tempoDisponivelParaTransicao)
        {
            contadorTempo += 1f * Time.deltaTime;
            contador = Mathf.Lerp(0f, tempoDisponivelParaTransicao, contadorTempo);
            material.SetFloat("_CutOff", contador);
            yield return new WaitForEndOfFrame();
        }
        FadeINTOObject.gameObject.SetActive(true);
        material.SetFloat("_CutOff", 0f);
        FuncaoPosTransicao();
    }

    IEnumerator TransicaoFadeOUT()
    {
        material.SetFloat("_CutOff", 1f);
        float contador = tempoDisponivelParaTransicao;
        float contadorTempo = 0;

        while(contador > 0)
        {
            contadorTempo += 1f * Time.deltaTime;
            contador = Mathf.Lerp(tempoDisponivelParaTransicao, 0f, contadorTempo);
            material.SetFloat("_CutOff", contador);
            yield return new WaitForEndOfFrame();
        }
        material.SetFloat("_CutOff", 0f);
    }
}
