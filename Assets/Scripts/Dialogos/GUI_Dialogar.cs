using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUI_Dialogar : MonoBehaviour
{
    [SerializeField] GameObject caixaDeDialogos;
    [SerializeField] TextMeshProUGUI texto;

    public void MostrarDialogo(string novoTexto)
    {
        caixaDeDialogos.SetActive(true);
        texto.text = novoTexto;
    }

    public void SairDoDialogo()
    {
        caixaDeDialogos.SetActive(false);
        texto.text = "";
    }
}
