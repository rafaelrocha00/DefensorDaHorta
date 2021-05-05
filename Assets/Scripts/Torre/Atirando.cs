using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Atirando : EventoTorre
{
    AtirarBasico tiro;
    bool EstaRecarregando = false;
    float TempoDeRecarga;

    public override bool Checar(Torre_Objeto objetoAtuante)
    {
        return true;
    }

    public override void Agir(Torre_Objeto objetoAtuante)
    {
        Collider[] Colisores = Physics.OverlapSphere(objetoAtuante.transform.position, objetoAtuante.GetRaio(), C_Jogo.instancia.Inimigos);
        if (Colisores.Length != 0)
        {
            GameObject inimigo = EncontrarODaFrente(Colisores);
            Olhar(objetoAtuante, inimigo.transform);
            Atirar(objetoAtuante, inimigo.transform.position);
            return;
        }

        ChecarTiro(objetoAtuante);
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

    public void Olhar(Torre_Objeto objetoAtuante, Transform PosicaoInimigo)
    {
        Transform Objeto = objetoAtuante.GetCabeca().transform;

        Vector3 Direcao = (PosicaoInimigo.position - Objeto.position).normalized;
        Direcao.y = 0f;
        Quaternion RotacaoLook = Quaternion.LookRotation(Direcao);
        Objeto.rotation = Quaternion.Slerp(Objeto.rotation, RotacaoLook, Time.deltaTime * 5f);
    }

    public IEnumerator PararDeOlhar(Transform cabeca, Quaternion atual, Quaternion natural, Action depois)
    {
        float contador = 0;
        while(contador < 1f)
        {
            cabeca.rotation = Quaternion.Lerp(atual, natural, contador);
            contador += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        depois?.Invoke();
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

    public void ChecarTiro(Torre_Objeto objetoAtuante)
    {
        if (tiro == null)
        {
            tiro = objetoAtuante.GetComponent<AtirarBasico>();
        }
    }

    public void Atirar(Torre_Objeto objetoAtuante, Vector3 pos)
    {
        if (EstaRecarregando)
        {
            return;
        }

        ChecarTiro(objetoAtuante);

        tiro.Atirar(pos);
        EstaRecarregando = true;
        TempoDeRecarga = objetoAtuante.GetTempoDeRecarga();
    }
}
