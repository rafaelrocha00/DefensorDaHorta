using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarUnico : AtirarBasico
{
    bool atirando;
    [SerializeField] Transform cabeca;

    public override void Atirar(Vector3 Target)
    {
        if (!atirando)
        {
           base.Atirar(Target);
            Debug.Log("Atirando apenas uma vez");
        }

        atirando = true;
    }

    public override void PararDeAtirar()
    {
        atirando = false;
    }
}
