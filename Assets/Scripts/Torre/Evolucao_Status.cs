using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Evolucao_Status", menuName = "Evolucao/Status")]
public class Evolucao_Status : Evolucao
{
    [SerializeField] Atributos atributaoParaEvoluir;
    [SerializeField] float valorDaEvolucao;
    public override void Evoluir()
    {
        base.Evoluir();
        switch (atributaoParaEvoluir)
        {
            case Atributos.Dano:
                torreAssociada.AumentarDano(valorDaEvolucao);
                break;
            case Atributos.Alcance:
                torreAssociada.AumentarAlcance(valorDaEvolucao);
                break;
            case Atributos.Recarga:
                torreAssociada.AumentarBonusDeRecarga(valorDaEvolucao);
                break;
            case Atributos.Velocidade:
                torreAssociada.AumentarVelocidade(valorDaEvolucao);
                break;
        }
    }
}
