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
    [SerializeField] bool padrao;

    void Start()
    {
        Botao = GetComponent<Button>();
        Botao.onClick.AddListener(MudarTorre);
        if (padrao)
        {
            Botao.onClick.Invoke();
            Botao.Select();
        }
    }

    void MudarTorre()
    {
        Menu.MudarTorreAtual(TorreAssociada, Descricao);
    }
}
