using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class C_Jogo : MonoBehaviour
{
    public static C_Jogo instancia;

    public LayerMask Chao;
    public LayerMask Inimigos;
    public float TempoPadraoDeInvocacao = 0.5f;
    public float OfssetInimigo = 0.1f;
    [SerializeField]Jogador jogadorAtual;

    public Color Padrao;
    public Color Selecionado;

    public Action CenaMudou;


    private void Awake()
    {
        if ((instancia != this) && (instancia != null))
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(this.gameObject);

        }
    }

    public void IniciarCoroutine(IEnumerator coroutina)
    {
        StartCoroutine(coroutina);
    }

    public void MudarCena(string nome)
    {
        StartCoroutine(MudarCenaAsyn(nome));
    }

    IEnumerator MudarCenaAsyn(string nome)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nome);
        while (!operation.isDone)
        {
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        CenaMudou?.Invoke();
    }

    public void FecharJogo()
    {
        Application.Quit();
    }

    public Jogador GetJogadorAtual()
    {
        return jogadorAtual;
    }

}
