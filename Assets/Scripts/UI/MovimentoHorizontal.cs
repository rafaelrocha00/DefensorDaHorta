using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoHorizontal : MonoBehaviour
{
    [SerializeField] float velocidade = 1f;
    [SerializeField] float movimento = 10f;
    Vector3 posicaoInicial;
    float tempoDesdeInicio;

    private void Start()
    {
        posicaoInicial = transform.position;
    }

    private void Update()
    {
        Mover();
    }

    void Mover()
    {
        transform.position = posicaoInicial + new Vector3(Mathf.PingPong(Time.realtimeSinceStartup * velocidade, movimento), 0, 0);
    }
}
