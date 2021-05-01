using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Jogador", menuName = "Jogador")]

public class Jogador: ScriptableObject
{
    public List<Torre> torres;
    public List<int> dialogosJaVistos = new List<int>();
    public int FasesLiberadas = 1;
    public ModoDeDificuldade dificuldadeEscolhida;
}
