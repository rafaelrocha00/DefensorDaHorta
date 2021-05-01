using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirando : EventoTorre
{
    bool EstaRecarregando = false;
    float TempoDeRecarga;

    public override bool Checar(Torre_Objeto objetoAtuante)
    {
        return true;
    }

    public override void Agir(Torre_Objeto objetoAtuante)
    {
        Collider[] Colisores = Physics.OverlapSphere(objetoAtuante.transform.position, objetoAtuante.GetTorre().Raio, C_Jogo.instancia.Inimigos);
        if (Colisores.Length != 0)
        {
            GameObject inimigo = EncontrarODaFrente(Colisores);
            Olhar(objetoAtuante, inimigo.transform);
            Atirar(objetoAtuante, inimigo.transform.position);
          
        }


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
        Transform Objeto = objetoAtuante.Cabeca.transform;

        Vector3 Direcao = (PosicaoInimigo.position - Objeto.position).normalized;
        Direcao.y = 0f;
        Quaternion RotacaoLook = Quaternion.LookRotation(Direcao);
        Objeto.rotation = Quaternion.Slerp(Objeto.rotation, RotacaoLook, Time.deltaTime * 5f);


    }

    public void Atirar(Torre_Objeto objetoAtuante, Vector3 pos)
    {
        if (EstaRecarregando)
        {
            TempoDeRecarga -= Time.deltaTime;
            if (TempoDeRecarga <= 0)
            {
                EstaRecarregando = false;
                TempoDeRecarga = 0;
            }
            return;
        }

        objetoAtuante.Atirar(pos);
        EstaRecarregando = true;
        TempoDeRecarga = objetoAtuante.GetTorre().TempoDeRecarga;
    }
}
