using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpcaoDeVelocidade : MonoBehaviour
{
    [SerializeField] float velocidade;
    [SerializeField] GameObject Ativo;
    public Action<OpcaoDeVelocidade> selecionado;
    [SerializeField] Button butao;
    [SerializeField]string opcaoNoTeclado = "";


    private void Start()
    {
        butao.onClick.AddListener(MudarVelocidade);
    }
    private void Update()
    {
        if(opcaoNoTeclado != "" && Input.GetButtonDown(opcaoNoTeclado))
        {
            MudarVelocidade();
        }

        if(Time.timeScale == velocidade)
        {
            MudarVelocidade();
        }
    }

    public void Desativar()
    {
        Ativo.SetActive(false);
    }

    public void Ativar()
    {
        Ativo.SetActive(true);
    }

    public void MudarVelocidade()
    {
        Debug.Log("Mudar velocidade chamado");
        selecionado?.Invoke(this);
        Time.timeScale = velocidade;
    }


}
