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
        Debug.Log("Atualizando");
        dano.text = "Dano: ";
        dano.text += torre.GetTorre().GetDano().ToString();
        alcance.text = "Alcance: ";
        alcance.text += torre.GetTorre().Raio.ToString();
        recarga.text = "Recarga: ";
        recarga.text += torre.GetTorre().TempoDeRecarga.ToString();
    }
}
