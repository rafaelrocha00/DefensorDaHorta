using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolucao : ScriptableObject
{
    protected Torre_Objeto torreAssociada;
    Torre_Evolucao C_Evolucao;
    [SerializeField] int posicao = 0;
    [SerializeField] Evolucao proximaEvolucao;
    [SerializeField] float preco;
    [SerializeField] string descricao;
    [SerializeField] Sprite icone;
    [SerializeField] Color cor;

    public virtual void Evoluir()
    {
        C_Evolucao.RetirarEvolucao(this);
        if(proximaEvolucao != null)
        {
            C_Evolucao.AdicionarEvolucao(proximaEvolucao);
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

    public void SetarTorreAEvoluir(Torre_Evolucao C_Evolucao,Torre_Objeto torreAssociada)
    {
        this.torreAssociada = torreAssociada;
        this.C_Evolucao = C_Evolucao;
    }

    public int GetPosicao()
    {
        return posicao;
    }
}
