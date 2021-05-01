using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_OpcoesDeVelocidade : MonoBehaviour
{
    [SerializeField]List<OpcaoDeVelocidade> opcoes = new List<OpcaoDeVelocidade>();

    private void Start()
    {
        for (int i = 0; i < opcoes.Count; i++)
        {
            opcoes[i].selecionado += DesativarOpcoes;
        }
    }

    public void DesativarOpcoes(OpcaoDeVelocidade opcao)
    {
        for (int i = 0; i < opcoes.Count; i++)
        {
            opcoes[i].Desativar();
        }

        opcao.Ativar();
        Debug.Log("Desativando opcoes");
    }
}
