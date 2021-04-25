using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Jogador
{
    public List<Torre> torres;
    public int FasesLiberadas = 1;
    Iinteragivel Selecionado;

    public void Selecionar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit Hit;
            Ray Raio = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Raio, out Hit, 100f, C_Jogo.instancia.Chao))
            {
                MonoBehaviour mono = Hit.collider.gameObject.GetComponent<MonoBehaviour>();
                if (mono is Iinteragivel)
                {
                    Iinteragivel interagivel = (Iinteragivel)mono;

                    if (Selecionado != null)
                    {
                        if(interagivel == Selecionado)
                        {
                            return;
                        }
                        Selecionado.Deselecionar();
                    }
                    interagivel.Selecionar(Color.white);
                    Selecionado = interagivel;
                }
            }
        }
      
        
    }
}
