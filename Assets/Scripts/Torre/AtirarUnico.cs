using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarUnico : AtirarBasico
{
    bool atirando;

    public override void Atirar(Vector3 Target)
    {
        if (!atirando)
        {
            base.Atirar(Target);
        }
        atirando = true;
    }

    public override void PararDeAtirar()
    {
        atirando = false;
    }
}
