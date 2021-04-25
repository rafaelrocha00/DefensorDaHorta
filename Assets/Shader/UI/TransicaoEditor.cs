using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
public class TransicaoEditor : MonoBehaviour
{
    public Material material;

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
        float contador = 0.5f;
        float contadorTempo = 0;
        while (contador < 1)
        {
            contadorTempo += 1.5f * Time.deltaTime;
            contador = Mathf.Lerp(0.5f, 1.3f, contadorTempo);
            material.SetFloat("_CutOff", contador);
            yield return new WaitForSeconds(0.1f);
        }
        FadeINTOObject.gameObject.SetActive(true);
        material.SetFloat("_CutOff", 0f);
        FuncaoPosTransicao();
    }

    IEnumerator TransicaoFadeOUT()
    {
        material.SetFloat("_CutOff", 1f);
        float contador = 1;
        float contadorTempo = 0;

        while(contador > 0)
        {
            contadorTempo += 1.5f * Time.deltaTime;
            contador = Mathf.Lerp(1.5f, -0.5f, contadorTempo);
            material.SetFloat("_CutOff", contador);
            yield return new WaitForSeconds(0.1f);
        }
        material.SetFloat("_CutOff", 0f);
    }
}
