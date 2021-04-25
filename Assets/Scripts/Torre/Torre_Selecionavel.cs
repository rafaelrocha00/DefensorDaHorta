using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre_Selecionavel : MonoBehaviour, Iinteragivel
{
    [SerializeField] List<Renderer> AfetadosPelaSelecao = new List<Renderer>();
    [SerializeField] public Material materialSelecionado;
    [SerializeField] Material materialBase;

    public void Selecionar(Color corSelecao)
    {
        Debug.Log("Selecionado");
        for (int i = 0; i < AfetadosPelaSelecao.Count; i++)
        {
            AfetadosPelaSelecao[i].material = materialSelecionado;
        }
    }

    public void Deselecionar()
    {
        for (int i = 0; i < AfetadosPelaSelecao.Count; i++)
        {
            AfetadosPelaSelecao[i].material = materialBase;
        }
    }
}
