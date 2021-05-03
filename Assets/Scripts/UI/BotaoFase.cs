using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoFase : MonoBehaviour
{
    Button botao;
    [SerializeField] int NumeroDaFase;
    public string NomeDaFase;
    [SerializeField] SelecaoDeFases selector;
    public Sprite imagemFase;
    Color corNormal;
    Image icon;
    [SerializeField] bool padrao = false;

    private void Start()
    {
        botao = GetComponent<Button>();
        SetarBotao();
        botao.onClick.AddListener(ChamarSelecionar);
        icon = GetComponent<Image>();
        corNormal = icon.color;
        if (padrao)
        {
            botao.onClick.Invoke();
            botao.Select();
        }
    }

    void ChamarSelecionar()
    {
        selector.Selecionar(this);
    }

    void SetarBotao()
    {
        if(C_Jogo.instancia.GetJogadorAtual().FasesLiberadas >=NumeroDaFase)
        {
            botao.interactable = true;
        }
        else
        {
            botao.interactable = false;
        }
    }

    public void Decelecionar()
    {
        icon.color = corNormal;
    }

    public void Selecionar()
    {
        icon.color = selector.corSelecionado;
    }


}
