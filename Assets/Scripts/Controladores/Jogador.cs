using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Jogador
{
    public List<Torre> torres;
    public List<int> dialogosJaVistos = new List<int>();
    public int FasesLiberadas = 1;
}
