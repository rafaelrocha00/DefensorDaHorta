using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoCarregarCen : MonoBehaviour
{
    Button botao;
    public string cena;
    public GameObject FadeInBlack;

    private void Start()
    {
        botao = GetComponent<Button>();
        TransicaoEditor Editor = Camera.main.gameObject.GetComponent<TransicaoEditor>();
        botao.onClick.AddListener(delegate { Editor.IniciarTransicaoFadeIN(FadeInBlack, IniciarMudarCena); });
    }

   

    public void IniciarMudarCena()
    {
        Time.timeScale = 1;
        C_Jogo.instancia.MudarCena(cena);
    }
}
