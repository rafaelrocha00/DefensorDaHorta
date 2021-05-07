using System;
using System.Collections.Generic;
using UnityEngine;

public class Torre_Evolucao : MonoBehaviour
{
    Torre_Objeto torre;
    [SerializeField] List<Evolucao> evolucoesIniciais = new List<Evolucao>();
    public Action<Torre_Objeto> EvolucaoAdicionada;


    private void Awake()
    {
        torre = GetComponent<Torre_Objeto>();
    }

    public Evolucao GetEvolucao(int index)
    {
        evolucoesIniciais[index].SetarTorreAEvoluir(this, torre);
        return evolucoesIniciais[index];
    }

    public int GetQuantidadeDeEvolucoes()
    {
        return evolucoesIniciais.Count;
    }

    public void EvoluirEMudarDeLevel()
    {
        for (int i = 0; i < evolucoesIniciais.Count; i++)
        {
            Evolucao ev = evolucoesIniciais[i];
            evolucoesIniciais.Add(ev.GetEvolucao());
            evolucoesIniciais.Remove(ev);
        }

        EvolucaoAdicionada?.Invoke(torre);
    }

    public void AdicionarEvolucao(Evolucao evolucao)
    {
        evolucoesIniciais.Add(evolucao);
        EvolucaoAdicionada?.Invoke(torre);
    }

    public void RetirarEvolucao(Evolucao evolucao)
    {
        evolucoesIniciais.Remove(evolucao);
    }

}
