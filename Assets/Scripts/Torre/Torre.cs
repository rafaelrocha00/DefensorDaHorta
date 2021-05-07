using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensoes;

[CreateAssetMenu(fileName = "Torre", menuName = "Torre")]
public class Torre: ScriptableObject
{
    public float Raio;
    public float TempoDeRecarga;
    public GameObject Bala;
    IAtiravel bala;
    public float GetDano()
    {
        if(bala == null)
        {
            bala = Bala.GetInterface<IAtiravel>();
        }

        return bala.GetDano();
    }

}
