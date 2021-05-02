using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        input.NadaSelecionado += FecharPainel;
    }

    public void ChecarObjetoSelecionado(GameObject objeto)
    {
        Torre_Objeto torre = objeto.GetComponent<Torre_Objeto>();

        if(torre != null && torre != selecionado)
        {
            AbrirPainelDeEvolucoes(torre);
        }

    }

    public void FecharPainel()
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

        selecionado = torre;
        painelDeEvolucoes.SetActive(true);
        FecharPainel();
        for (int i = 0; i < torre.GetQuantidadeDeEvolucoes(); i++)
        {
            GameObject botao = Instantiate(BotaoEvolucao, painelDeEvolucoes.transform);
            evolucoesAbertas.Add(botao);
            ComponentesPainelEvolucao refe = botao.GetComponent<ComponentesPainelEvolucao>();
            refe.SetarEvolucao(torre.GetEvolucao(i));
        }
    }
}
