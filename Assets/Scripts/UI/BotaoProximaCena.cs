using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoProximaCena : MonoBehaviour
{
    [SerializeField] GameObject FadeInBlack;


    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(IrParaProximaFase);    
    }

    public void IrParaProximaFase()
    {
        TransicaoEditor Editor = Camera.main.gameObject.GetComponent<TransicaoEditor>();
        Editor.IniciarTransicaoFadeIN(FadeInBlack, IrParaProximaFase_Final);
    }

    void IrParaProximaFase_Final()
    {
        Time.timeScale = 1;
        if(C_Fase.instancia.nomeDaProximaFase == "")
        {
            C_Jogo.instancia.MudarCena("MenuPrincipal");
            return;
        }
        C_Jogo.instancia.MudarCena(C_Fase.instancia.nomeDaProximaFase);
    }
}
