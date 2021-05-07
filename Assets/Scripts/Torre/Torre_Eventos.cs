using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre_Eventos : MonoBehaviour
{
    Torre_Objeto torre;
    EventoTorre EventoAtual;

    private void Awake()
    {
        torre = GetComponent<Torre_Objeto>();
    }

    public void MudarEventoAtual(EventoTorre evento)
    {
        EventoAtual = evento;
        EventoAtual.Setar(torre);
    }

    private void Update()
    {
        if ((EventoAtual != null) && (EventoAtual.Checar(torre)))
        {
            EventoAtual.Agir(torre);
        }
    }
}
