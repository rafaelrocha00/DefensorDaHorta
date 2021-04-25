using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTorreBotao : MonoBehaviour
{
    Button Botao;
    [SerializeField]MenuTorre Menu;
    [SerializeField] GameObject TorreAssociada;
    [TextArea][SerializeField] string Descricao;

    void Start()
    {
        Botao = GetComponent<Button>();
        Botao.onClick.AddListener(MudarTorre);
    }

    void MudarTorre()
    {
        Menu.MudarTorreAtual(TorreAssociada, Descricao);
    }
}
