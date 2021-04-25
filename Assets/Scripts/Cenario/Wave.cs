using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave")]
public class Wave: ScriptableObject
{
    public List<Inimigo_Tempo> ListaDeInimigos;

    public Inimigo_Tempo this[int key]
    {
        get
        {
            return ListaDeInimigos[key];
        }
        set
        {
            ListaDeInimigos[key] = value;
        }
    }
}
