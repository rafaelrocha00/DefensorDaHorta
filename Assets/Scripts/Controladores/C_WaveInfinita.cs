using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_WaveInfinita : MonoBehaviour
{
    [SerializeField] List<Inimigo_Tempo> inimigosDisponiveis = new List<Inimigo_Tempo>();
    [SerializeField] Waypoint WaypointInicial;

    [SerializeField] float tempoEntreWaves = 1f;
    [SerializeField] float tempoEntreInimigos = 0.5f;

    [SerializeField] float valorFlowTotal = 4.1f;
    [SerializeField] float influenciaDePicos = 1.2f;
    float contadorDePicos = 0;
    [SerializeField] float tempoEntrePicos = 2.5f;
    float pontosDaWaveAnterior = 0;
    float pontosDisponiveisParaEssaWave = 0;
    int waveAtual = 0;
    int tentativasDeCompra = 0;
    int valorInicial = 1;
    [SerializeField] int maximoDeTentativas = 5;

    private void Start()
    {
        StartCoroutine(ProcessarWave());
    }


    IEnumerator ProcessarWave()
    {
        while (true)
        {
            while(pontosDisponiveisParaEssaWave > 0 && tentativasDeCompra < maximoDeTentativas)
            {
                Inimigo inimigo = EscolherInimigoParaWave();
                if(inimigo != null)
                {
                    InstanciarInimigo(inimigo);
                    yield return new WaitForSeconds(tempoEntreInimigos);
                }
                else
                {
                    tentativasDeCompra++;
                }
            }

            tentativasDeCompra = 0;
            waveAtual++;
            pontosDisponiveisParaEssaWave = EscolherNovaPontuacaoMatematicamente();
            yield return new WaitForSeconds(tempoEntreWaves);
        }
    }

    float EscolherNovaPontuacaoMatematicamente()
    {
        return Mathf.Ceil(valorInicial + Mathf.Sin(waveAtual * tempoEntrePicos) * influenciaDePicos + waveAtual * valorFlowTotal/5f);
    }

    Inimigo EscolherInimigoParaWave()
    {
        int random = Random.Range(0, inimigosDisponiveis.Count);
        if(inimigosDisponiveis[random].tempo <= pontosDisponiveisParaEssaWave)
        {
            pontosDisponiveisParaEssaWave -= inimigosDisponiveis[random].tempo;
            return inimigosDisponiveis[random].inimigo;
        }

        return null;
    }

    void InstanciarInimigo(Inimigo inimigo)
    {
        Vector3 dir = WaypointInicial.GetNovoWaypoint().Position - WaypointInicial.transform.position;
        Quaternion Rotacao = Quaternion.LookRotation(dir);
        GameObject InimigoInvocadoObjeto = Instantiate(inimigo.inimigo, WaypointInicial.Position, Rotacao);
        Inimigo_Objeto inimigoObjeto = InimigoInvocadoObjeto.GetComponent<Inimigo_Objeto>();
        inimigo.SetarInfoEmInimigo(inimigoObjeto);

        inimigoObjeto.MudarWaypoint(WaypointInicial);
        inimigoObjeto.AcertouVida += C_Fase.instancia.RetirarVida;
    }
}
