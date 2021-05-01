using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BotaoTipoDeFase : MonoBehaviour
{
    [SerializeField] ModoDeDificuldade tipoAMudar;
    [SerializeField] SelecaoDeFases seletor;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { seletor.MudarTipoDeFase(tipoAMudar); });
    }
}
