using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Torre", menuName = "Torre")]
public class Torre: ScriptableObject
{
    public float Raio;
    public float TempoDeRecarga;
    public GameObject Bala;
}
