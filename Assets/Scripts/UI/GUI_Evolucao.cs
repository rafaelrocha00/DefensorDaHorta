using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUI_Evolucao : MonoBehaviour
{
    [SerializeField] Torre_Objeto selecionado;
    [SerializeField] GameObject painelDeEvolucoes;
    [SerializeField] GameObject BotaoEvolucao;
    List<GameObject> evolucoesAbertas = new List<GameObject>();

    private void Start()
    {
        C_Input input = C_Jogo.instancia.GetComponent<C_Input>();
        input.ObjetoSelecionado += ChecarObjetoSelecionado;
        input.NadaSelecionado += LimparPainel;
    }

    public void ChecarObjetoSelecionado(GameObject objeto)
    {
        Torre_Objeto torre = objeto.GetComponent<Torre_Objeto>();

        if(torre != null && torre != selecionado)
        {
            AbrirPainelDeEvolucoes(torre);
        }

    }

    public void LimparPainel()
    {
        if (evolucoesAbertas.Count == 0) return;
        for (int i = 0; i < evolucoesAbertas.Count; i++)
        {
            Destroy(evolucoesAbertas[i]);
        }

        selecionado = null;
    }

    public void AbrirPainelDeEvolucoes(Torre_Objeto torre)
    {
        if (painelDeEvolucoes == null) return;

        LimparPainel();
        selecionado = torre;
        painelDeEvolucoes.SetActive(true);


        for (int i = 0; i < torre.GetQuantidadeDeEvolucoes(); i++)
        {
            InstanciarEvolucao(torre.GetEvolucao(i));
        }
    }

    public void AtualizarPainelDeEvolucoes()
    {
        AbrirPainelDeEvolucoes(selecionado);
    }

    public void InstanciarEvolucao(Evolucao evolucao)
    {
        GameObject botao = Instantiate(BotaoEvolucao, painelDeEvolucoes.transform);
        evolucoesAbertas.Add(botao);
        botao.transform.SetSiblingIndex(evolucao.GetPosicao());
        ComponentesPainelEvolucao refe = botao.GetComponent<ComponentesPainelEvolucao>();
        refe.SetarEvolucao(evolucao, this);
    }
}
