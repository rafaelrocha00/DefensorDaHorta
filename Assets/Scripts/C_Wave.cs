using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class C_Wave : MonoBehaviour
{
    public List<Wave> Waves;
    bool WaveComecou = false;
    int IndexWaveAtual = 0;
    int IndexInimigoAtual = 0;
    public Waypoint WaypointInicial;
    public List<Inimigo_Objeto> InimigosPresentes;

    public float VidaAtual = 20;
    public float DinheiroInicial = 50;
    public Action Venceu;
    public Action WaveMudou;
    bool venceu = false;

    public Action Perdeu;
    public Action DinheiroMudou;
    public Action VidaMudou;

    private void Start()
    {
        C_Fase.instancia.Inicializar(VidaAtual, DinheiroInicial);
    }

    void Update()
    {
        if(IndexWaveAtual == Waves.Count)
        {
            ChecarVitoria();
        }
    }

    public void IniciarWaves()
    {
        StartCoroutine(ProcessarWave());
        WaveComecou = true;
    }

    IEnumerator ProcessarWave()
    {
        for (int i = 0; i < Waves.Count; i++)
        {
            IndexWaveAtual++;
            IndexInimigoAtual = 0;

            WaveMudou?.Invoke();

            for (int j = 0; j < Waves[i].ListaDeInimigos.Count; j++)
            {
                IndexInimigoAtual++;
                Inimigo_Tempo inimigoWave = Waves[i][j];
                InstanciarInimigo(inimigoWave.inimigo);
                float tempo = GetTempoEntreInvocacoes(inimigoWave.tempo);
               
                yield return new WaitForSeconds(tempo);
            }
        }

        yield return null;
    }

    float GetTempoEntreInvocacoes(float tempoInimigo)
    {
        if (tempoInimigo == 0)
        {
            return C_Jogo.instancia.TempoPadraoDeInvocacao;
        }
        else
        {
            return tempoInimigo;
        }
    }

    public void InstanciarInimigo(Inimigo info)
    {
        Vector3 dir = WaypointInicial.GetNovoWaypoint().Position - WaypointInicial.transform.position;
        Quaternion Rotacao = Quaternion.LookRotation(dir);
        GameObject InimigoInvocadoObjeto = Instantiate(info.inimigo, WaypointInicial.Position, Rotacao);
        Inimigo_Objeto inimigoObjeto = InimigoInvocadoObjeto.GetComponent<Inimigo_Objeto>();
        info.SetarInfoEmInimigo(inimigoObjeto);

        InimigosPresentes.Add(inimigoObjeto);
        inimigoObjeto.MudarWaypoint(WaypointInicial);
        inimigoObjeto.AcertouVida += C_Fase.instancia.RetirarVida;
        inimigoObjeto.Morreu += Retirarinimigo;
    }

    public void Retirarinimigo(Inimigo_Objeto inimigo)
    {
        InimigosPresentes.Remove(inimigo);
    }

    public void ChecarVitoria()
    {
        if((InimigosPresentes.Count == 0)&&(IndexInimigoAtual == Waves[IndexWaveAtual-1].ListaDeInimigos.Count))
        {
            Debug.Log("Fim de Partida.");
            if (!venceu)
            {
                C_Jogo.instancia.jogador.FasesLiberadas++;
                venceu = true;
                Venceu?.Invoke();

            }
        }
    }

    public int GetWaveAtual()
    {
        return IndexWaveAtual;
    }



}
