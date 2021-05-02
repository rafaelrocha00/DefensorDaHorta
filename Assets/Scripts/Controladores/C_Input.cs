using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Iinteragivel interagivel = FindInterface<Iinteragivel>(Hit.collider.gameObject) as Iinteragivel;
                Debug.Log(Hit.collider.gameObject.name);
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

    public MonoBehaviour FindInterface<T>(GameObject objeto)
    {
        MonoBehaviour[] mono = objeto.GetComponents<MonoBehaviour>();
        for (int i = 0; i < mono.Length; i++)
        {
            if (mono[i] is T) return mono[i];
        }

        return null;
    }

}
