using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construcao : EventoTorre
{
    List<Renderer> render;

    public override bool Checar(Torre_Objeto objetoAtuante)
    {
        return true;
    }

    public override void Agir(Torre_Objeto objetoAtuante)
    {
        C_Jogo.instancia.GetComponent<C_Input>().podeSelecionar = false;
        RaycastHit Hit;
        Ray Raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Raio, out Hit, 100f, C_Jogo.instancia.Chao))
        {
            if (Hit.collider != null)
            {
                objetoAtuante.gameObject.transform.position = Hit.point;

                if (render == null)
                {
                    render = objetoAtuante.GetComponent<Torre_Objeto>().Render;
                }

                if (Hit.collider.gameObject.CompareTag("TerrenoAcessivel"))
                {
                    for (int i = 0; i < render.Count; i++)
                    {
                        render[i].material.color = Color.green;

                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        for (int i = 0; i < render.Count; i++)
                        {
                            render[i].material.color = Color.white;

                        }
                        C_Audio.audio.PlayAudioConstrucao();
                        objetoAtuante.gameObject.transform.position = new Vector3(Mathf.Round(Hit.point.x), Mathf.Round(Hit.point.y), Mathf.Round(Hit.point.z));
                        objetoAtuante.GetComponent<LineRenderer>().enabled = false;
                        objetoAtuante.gameObject.layer = LayerMask.NameToLayer("Chao");
                        C_Jogo.instancia.GetComponent<C_Input>().podeSelecionar = true;

                        objetoAtuante.EventoAtual = new Atirando();
                    }
                }
                else
                {
                    for (int i = 0; i < render.Count; i++)
                    {
                        render[i].material.color = Color.red;

                    }

                }
            }
            else
            {
                Debug.Log("Não acertou objeto algum");
            }
          
        }
        
       

    }
}
