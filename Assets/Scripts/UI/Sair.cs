using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sair : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(C_Jogo.instancia.FecharJogo);
    }
}
