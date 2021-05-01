using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField]GUI_Dialogar gui;
    [SerializeField][TextArea] List<string> dialogos = new List<string>();
    int dialogoAtual;
    bool mostrandoDialogo;
    [SerializeField] bool mostrarNoStart;

    private void Start()
    {
        if (mostrarNoStart)
        {
            IniciarDialogo();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && mostrandoDialogo)
        {
            MostrarDialogo();
        }
    }

    public void IniciarDialogo()
    {
        if (ChecarSave()) return;
        mostrandoDialogo = true;
        MostrarDialogo();
    }

    bool ChecarSave()
    {
        return C_Jogo.instancia.GetJogadorAtual().dialogosJaVistos.Exists(x => x == id);
    }

    void MostrarDialogo()
    {
        if (dialogoAtual >= dialogos.Count)
        {
            mostrandoDialogo = false;
            C_Jogo.instancia.GetJogadorAtual().dialogosJaVistos.Add(id);
            gui.SairDoDialogo();
            return;
        }
        gui.MostrarDialogo(dialogos[dialogoAtual]);
        dialogoAtual++;

    }
}
