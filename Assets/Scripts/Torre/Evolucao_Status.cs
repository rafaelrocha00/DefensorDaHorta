using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Evolucao_Status", menuName = "Evolucao/Status")]
public class Evolucao_Status : Evolucao
{
    [SerializeField] Atributos atributaoParaEvoluir;
    [SerializeField] float valorDaEvolucao;
    public override void Evoluir(Torre_Objeto torre)
    {
        switch (atributaoParaEvoluir)
        {
            case Atributos.Dano:
                break;
        }
    }
}
