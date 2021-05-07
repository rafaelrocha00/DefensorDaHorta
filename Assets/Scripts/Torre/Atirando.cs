using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Atirando : EventoTorre
{
    AtirarBasico tiro;
    Torre_Rotacao rotacao;
    bool EstaRecarregando = false;
    float TempoDeRecarga;

    public override void Setar(Torre_Objeto objetoAtuante)
    {
        tiro = objetoAtuante.GetComponent<AtirarBasico>();
        rotacao = objetoAtuante.GetComponent<Torre_Rotacao>();
    }

    public override bool Checar(Torre_Objeto objetoAtuante)
    {
        return true;
    }

    public override void Agir(Torre_Objeto objetoAtuante)
    {
        AtualizarRecarga();

        Collider[] Colisores = Physics.OverlapSphere(objetoAtuante.transform.position, objetoAtuante.GetRaio(), C_Jogo.instancia.Inimigos);
        if (Colisores.Length != 0)
        {
            GameObject inimigo = EncontrarODaFrente(Colisores);
            rotacao.Olhar(objetoAtuante, inimigo.transform);
            Atirar(objetoAtuante, inimigo.transform.position);
            return;
        }

        tiro.PararDeAtirar();

    }

    public GameObject EncontrarODaFrente(Collider[] colisoresInimigos)
    {
        Inimigo_Objeto[] inimigos = new Inimigo_Objeto[colisoresInimigos.Length];
        for (int i = 0; i < inimigos.Length; i++)
        {
            inimigos[i] = colisoresInimigos[i].GetComponent<Inimigo_Objeto>();
        }

        int inimigoAFrente = 0;

        for (int i = 0; i < inimigos.Length; i++)
        {
            if(inimigos[i].GetPosicaoNaFila() <= inimigos[inimigoAFrente].GetPosicaoNaFila())
            {
                inimigoAFrente = i;
            }
        }

        return inimigos[inimigoAFrente].gameObject;
    }

    public void AtualizarRecarga()
    {
        TempoDeRecarga -= Time.deltaTime;
        if (TempoDeRecarga <= 0)
        {
            EstaRecarregando = false;
            TempoDeRecarga = 0;
        }
    }

    public void Atirar(Torre_Objeto objetoAtuante, Vector3 pos)
    {
        if (EstaRecarregando)
        {
            Debug.Log("Carregando tiro");
            return;
        }

        tiro.Atirar(pos);
        EstaRecarregando = true;
        TempoDeRecarga = objetoAtuante.GetTempoDeRecarga();
    }
}
