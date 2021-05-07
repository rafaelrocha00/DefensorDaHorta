using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EstatusTorre : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI dano;
    [SerializeField]TextMeshProUGUI alcance;
    [SerializeField]TextMeshProUGUI recarga;

    private void Start()
    {
        C_Fase.instancia.TorreSelecionada += Atualizar;
    }

    public void Atualizar(Torre_Objeto torre)
    {
        dano.text = "Dano: ";
        dano.text += torre.GetDano().ToString();
        alcance.text = "Alcance: ";
        alcance.text += torre.GetRaio().ToString();
        recarga.text = "Recarga: ";
        recarga.text += torre.GetTempoDeRecarga().ToString();
    }
}
