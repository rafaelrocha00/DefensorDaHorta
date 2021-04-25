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
        Collider[] Colisores = Physics.OverlapSphere(objetoAtuante.transform.position, objetoAtuante.TorreAssociada.Raio, C_Jogo.instancia.Inimigos);
        if (Colisores.Length != 0)
        {
            Olhar(objetoAtuante, Colisores[0].transform);
            Atirar(objetoAtuante, Colisores);
          
        }


    }

    public void Olhar(Torre_Objeto objetoAtuante, Transform PosicaoInimigo)
    {
        Transform Objeto = objetoAtuante.Cabeca.transform;

        Vector3 Direcao = (PosicaoInimigo.position - Objeto.position).normalized;
        Direcao.y = 0f;
        Quaternion RotacaoLook = Quaternion.LookRotation(Direcao);
        Objeto.rotation = Quaternion.Slerp(Objeto.rotation, RotacaoLook, Time.deltaTime * 5f);


    }

    public void Atirar(Torre_Objeto objetoAtuante, Collider[] Colisores)
    {
        if (!EstaRecarregando)
        {
            if (Colisores.Length != 0)
            {
                objetoAtuante.Atirar(Colisores[0].gameObject.transform.position);                
                EstaRecarregando = true;
                TempoDeRecarga = objetoAtuante.TorreAssociada.TempoDeRecarga;
            }

        }
        else
        {
            TempoDeRecarga -= Time.deltaTime;
            if (TempoDeRecarga <= 0)
            {
                EstaRecarregando = false;
                TempoDeRecarga = 0;
            }
        }
    }
}
