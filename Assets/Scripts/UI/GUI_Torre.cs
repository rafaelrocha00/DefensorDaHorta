using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Torre : MonoBehaviour
{
    Torre_Objeto Torre;
    public float Largura;
    public float OfssetChao = 0.4f;
    float Raio;
    LineRenderer Line;
    public Material material;
    public Color cor;
    
    private void Start()
    {
        Torre = GetComponent<Torre_Objeto>();
        Line = gameObject.AddComponent<LineRenderer>();

    }

    private void Update()
    {
        if (Line != null && Line.enabled)
        {
            DesenharRaio();
        }
    }

    void DesenharRaio()
    {
        Debug.Log("Desenhando raio");
        int Segmentos = 360;
        Line.useWorldSpace = false;
        Line.startWidth = Largura;
        Line.endWidth = Largura;
        Line.positionCount = Segmentos + 1;
        Line.material = material;
        Line.startColor = cor;
        Line.endColor = cor;

        int PontosCount = Segmentos + 1;
        Vector3[] Pontos = new Vector3[PontosCount];
        Raio = Torre.GetRaio();

        for (int i = 0; i < PontosCount; i++)
        {
            float Rad = Mathf.Deg2Rad * (i * 360f / Segmentos);
            Pontos[i] = new Vector3(Mathf.Sin(Rad) * Raio, OfssetChao, Mathf.Cos(Rad) * Raio);
        }

        Line.SetPositions(Pontos);
    }
}
