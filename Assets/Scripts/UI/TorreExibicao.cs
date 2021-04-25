using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreExibicao : MonoBehaviour
{
    [SerializeField] float velocidadeAngular;
    Vector3 movimento;

    private void Start()
    {
        movimento.y = velocidadeAngular;
    }

    private void Update()
    {
        GirarTorre();
    }

    void GirarTorre()
    {
        transform.rotation *= Quaternion.Euler(0, velocidadeAngular * Time.deltaTime, 0);
    }
}
