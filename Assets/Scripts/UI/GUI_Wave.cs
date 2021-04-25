using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUI_Wave : MonoBehaviour
{
    [SerializeField] GameObject PainelVenceu;
    [SerializeField] GameObject PainelPerdeu;
    [SerializeField] TextMeshProUGUI TextoDinheiro;
    [SerializeField] TextMeshProUGUI TextoVida;
    [SerializeField] TextMeshProUGUI TextoWave;
    [SerializeField] TextMeshProUGUI TextoPreco;
    C_Wave wave;

    private void Start()
    {
        wave = GetComponent<C_Wave>();
        wave.Venceu += MostrarPainelVenceu;
        C_Fase.instancia.Perdeu += MostrarPainelPerdeu;
        C_Fase.instancia.DinheiroMudou += AtualizarPainelDinheiro;
        C_Fase.instancia.VidaMudou += AtualizarPainelVida;
        wave.WaveMudou += AtualizarPainelWave;
        AtualizarPainelDinheiro();
        AtualizarPainelVida();
        AtualizarPainelWave();
    }


    void MostrarPainelVenceu()
    {
        PainelVenceu.SetActive(true);
    }
    public void AtualizarTextoPreco(float novoPreco)
    {
        string texto = "$" + novoPreco.ToString();
        TextoPreco.text = texto;
    }

    void MostrarPainelPerdeu()
    {
        PainelPerdeu.SetActive(true);
    }

    void AtualizarPainelDinheiro()
    {
        TextoDinheiro.text = C_Fase.instancia.GetDinheiro().ToString();
    }

    void AtualizarPainelVida()
    {
        float vida = C_Fase.instancia.GetVida();
        if(vida >= 0)
        TextoVida.text = vida.ToString();
    }

    void AtualizarPainelWave()
    {
        TextoWave.text = wave.GetWaveAtual().ToString() + "/" + wave.Waves.Count.ToString();
    }
}
