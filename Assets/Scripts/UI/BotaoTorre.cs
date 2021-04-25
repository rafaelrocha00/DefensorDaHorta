﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotaoTorre : MonoBehaviour, IPointerEnterHandler
{
    Button Botao;
    [SerializeField] float Preco;
    [SerializeField]GameObject TorreAssociada;
    [SerializeField] GUI_Wave gui;

    void Start()
    {
        gui = GameObject.Find("Fase").GetComponent<GUI_Wave>();
        Botao = GetComponent<Button>();
        Botao.onClick.AddListener(ConstruirTorre);
        C_Fase.instancia.DinheiroMudou += AtualizarTorre;
        AtualizarTorre();
    }

    void ConstruirTorre()
    {
        if (C_Fase.instancia.RetirarDinheiro(Preco))
        {
            Torre_Objeto TorreInvocada = Instantiate(TorreAssociada, Vector3.zero, TorreAssociada.transform.rotation).GetComponent<Torre_Objeto>();
            TorreInvocada.EventoAtual = new Construcao();
        }
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gui.AtualizarTextoPreco(Preco);
    }

    void AtualizarTorre()
    {
        if(Botao != null)
        {
            if (C_Fase.instancia.GetDinheiro() >= Preco)
            {
                Botao.interactable = true;
            }
            else
            {
                Botao.interactable = false;

            }
        }
   
    }
}
