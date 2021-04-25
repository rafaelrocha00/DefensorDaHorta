using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoDestruir : MonoBehaviour
{
    Button botao;

    private void Start()
    {
        botao = GetComponent<Button>();
        botao.onClick.AddListener(Destruir);
    }

    public void Destruir()
    {
        Destroy(gameObject);
        Debug.Log("Metodo não funciona");
    }

}
