using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComponentesPainelEvolucao : MonoBehaviour
{
    Evolucao evolucao;
    [SerializeField] TextMeshProUGUI preco;
    [SerializeField] TextMeshProUGUI descricao;
    [SerializeField] Image icon;
    [SerializeField] Image Cell;
    [SerializeField] Button botao;

    private void Update()
    {
        if(C_Fase.instancia.GetDinheiro() >= evolucao.GetPreco())
        {
            LigarBotao();
        }
        else
        {
            DesligarBotao();
        }
    }

    public void LigarBotao()
    {
        botao.interactable = true;
    }

    public void DesligarBotao()
    {
        botao.interactable = false;
    }

    public void SetarEvolucao(Evolucao evolucao)
    {
        this.evolucao = evolucao;
        preco.text = evolucao.GetPreco().ToString();
        descricao.text = evolucao.GetDescricao().ToString();
        icon.sprite = evolucao.GetIcone();
        icon.SetNativeSize();
        Cell.color = evolucao.GetCor();
        botao.onClick.AddListener(Evoluir);
    }

    public void Evoluir()
    {
        if(C_Fase.instancia.GetDinheiro() < evolucao.GetPreco())
        {
            Debug.Log(" S Possui" + C_Fase.instancia.GetDinheiro() + " Precisa de " + evolucao.GetPreco());
            return;
        }

        Debug.Log("Possui" + C_Fase.instancia.GetDinheiro() + " Precisa de " + evolucao.GetPreco());

        evolucao.Evoluir();
        C_Fase.instancia.RetirarDinheiro(evolucao.GetPreco());
        Destroy(gameObject);
    }

}
