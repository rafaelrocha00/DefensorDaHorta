using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inimigo", menuName = "Inimigo")]
public class Inimigo: ScriptableObject
{
    [SerializeField]float velocidade;
    [SerializeField]float vidaTotal;
    [SerializeField]int dano;
    [SerializeField]int dinheiroGanho;
    public GameObject inimigo;

    public void SetarInfoEmInimigo(Inimigo_Objeto inimigo)
    {
        inimigo.velocidade = velocidade;
        inimigo.vidaTotal = vidaTotal;
        inimigo.dano = dano;
        inimigo.DinheiroGanho = dinheiroGanho;
    }
}
