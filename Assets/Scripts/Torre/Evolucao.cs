using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolucao : ScriptableObject
{
    [SerializeField] Evolucao proximaEvolucao;
    [SerializeField] float preco;

    public virtual void Evoluir(Torre_Objeto torre)
    {

    }

    public float GetPreco()
    {
        return preco;
    }

    public Evolucao GetEvolucao()
    {
        return proximaEvolucao;
    }
}
