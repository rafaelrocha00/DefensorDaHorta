using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensoes;

public class C_Input : MonoBehaviour
{
    public Action<GameObject> ObjetoSelecionado;
    public Action NadaSelecionado;
    Iinteragivel Selecionado;
    public bool podeSelecionar = true;

    private void Update()
    {
        Selecionar();
    }

    public void Selecionar()
    {
        if (Input.GetMouseButtonDown(0) && podeSelecionar)
        {
            RaycastHit Hit;
            Ray Raio = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Raio, out Hit, 100f))
            {
                Iinteragivel interagivel = Hit.collider.gameObject.GetInterface<Iinteragivel>();
                if (interagivel != null)
                {
                    if (Selecionado != null && Selecionado != interagivel)
                    {
                        Selecionado.Deselecionar();
                    }
                    interagivel.Selecionar(Color.white);
                    Selecionado = interagivel;
                    ObjetoSelecionado?.Invoke(Hit.collider.gameObject);
                    return;
                }
            }

            if (CheckUI.IsPointerOverUIObject()) return;

            if(Selecionado != null)
            {
                Selecionado.Deselecionar();
                Selecionado = null;
            }

            NadaSelecionado?.Invoke();
        }


    }



}
