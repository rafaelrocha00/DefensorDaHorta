using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoResertarCena : MonoBehaviour
{
    [SerializeField] GameObject FadeInBlack;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ResertarCena);
    }

    public void ResertarCena()
    {
        TransicaoEditor Editor = Camera.main.gameObject.GetComponent<TransicaoEditor>();
        Editor.IniciarTransicaoFadeIN(FadeInBlack, ResertarCena_Final);
    }

    void ResertarCena_Final()
    {
        Time.timeScale = 1;
        C_Jogo.instancia.MudarCena(C_Fase.instancia.nomeDaFase);
    }

}
