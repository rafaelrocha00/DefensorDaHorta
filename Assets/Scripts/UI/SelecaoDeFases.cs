using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecaoDeFases : MonoBehaviour
{
    BotaoFase faseAtual;
    [SerializeField]Image ViewFase;
    [SerializeField]Button Avancar;
    [SerializeField] Transform seletor;
    public Color corSelecionado;
    [SerializeField] List<GameObject> Fases;
    [SerializeField] float velocidadeSeletor = 5f;
    [SerializeField] GameObject FadeInBlack;
    TipoDeFase tipoAtual;

    private void Start()
    {
        for (int i = 0; i < Fases.Count; i++)
        {
            if(C_Jogo.instancia.jogador.FasesLiberadas >= i)
            {
                Fases[i].SetActive(true);
            }
        }
        Avancar.onClick.AddListener(MudarCena);
        Avancar.interactable = false;
    }

    public void Selecionar(BotaoFase novaFase)
    {
        if(faseAtual != null)
        faseAtual.Decelecionar();
        faseAtual = novaFase;
        faseAtual.Selecionar();
        if (!ViewFase.gameObject.activeInHierarchy)
        {
            ViewFase.gameObject.SetActive(true);
        }
        ViewFase.sprite = faseAtual.imagemFase;
        if (seletor.gameObject.activeInHierarchy)
        {
            StartCoroutine(MoverSeletor());
        }
        else
        {
            seletor.gameObject.SetActive(true);
            seletor.transform.position = faseAtual.transform.position;
        }

        Avancar.interactable = true;

    }

    IEnumerator MoverSeletor()
    {
        while(Vector3.Distance(seletor.position, faseAtual.transform.position) > 0.1f)
        {
            seletor.position = Vector3.Slerp(seletor.position, faseAtual.transform.position, Time.deltaTime * velocidadeSeletor);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void MudarCena()
    {
        if(faseAtual != null)
        {
            TransicaoEditor Editor = Camera.main.gameObject.GetComponent<TransicaoEditor>();
            string faseFinal = faseAtual.NomeDaFase + "_" + tipoAtual.ToString();
            Editor.IniciarTransicaoFadeIN(FadeInBlack, 
                delegate { C_Jogo.instancia.MudarCena(faseFinal); });
        }

    }

    public void MudarTipoDeFase(TipoDeFase novoTipo)
    {
        tipoAtual = novoTipo;
    }
}

public enum TipoDeFase
{
    normal,
    dificil,
    infinito
}
