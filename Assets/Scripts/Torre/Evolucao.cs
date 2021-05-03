using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolucao : ScriptableObject
{
    protected Torre_Objeto torreAssociada;
    [SerializeField] Evolucao proximaEvolucao;
    [SerializeField] float preco;
    [SerializeField] string descricao;
    [SerializeField] Sprite icone;
    [SerializeField] Color cor;

    public virtual void Evoluir()
    {
        torreAssociada.RetirarEvolucao(this);
        if(proximaEvolucao != null)
        {
            torreAssociada.AdicionarEvolucao(proximaEvolucao);
        }
    }

    public float GetPreco()
    {
        return preco;
    }

    public Evolucao GetEvolucao()
    {
        return proximaEvolucao;
    }

    public string GetDescricao()
    {
        return descricao;
    }

    public Color GetCor()
    {
        return cor;
    }

    public Sprite GetIcone()
    {
        return icone;
    }

    public void SetarTorreAEvoluir(Torre_Objeto torre)
    {
        torreAssociada = torre;
    }
}
