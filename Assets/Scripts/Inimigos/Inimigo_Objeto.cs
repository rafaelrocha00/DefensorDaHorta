using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Objeto: MonoBehaviour
{
    int posicaoNaFila = -1;
    //Status
    public float velocidade;
    float velocidadeinicial;
    public float vidaTotal;
    [HideInInspector]public float vidaAtual;
    public int dano;
    public int DinheiroGanho;

    //FX
    public Renderer Render;
    [SerializeField]GameObject ParticulaDano;
    [SerializeField] int MaterialBase;
    Color corBase;
    [SerializeField]Color CorDano;
    C_Camera Camera;

    //Waypoints
    Waypoint waypointAtual;

    // Eventos
    public Action<float> AcertouVida;
    public Action LevouDano;
    public Action<Inimigo_Objeto> Morreu;

    private void Start()
    {
        velocidadeinicial = velocidade;
        this.transform.position = waypointAtual.Position;
        vidaAtual = vidaTotal;
        Camera = C_Jogo.instancia.GetComponent<C_Camera>();
        corBase = Render.materials[MaterialBase].GetColor("_Color");
    }

    private void Update()
    {
        Mover();
    }

    void Mover()
    {
        if (waypointAtual == null) return;

        Vector3 dir = waypointAtual.Position - transform.position;
        float velocidadeNormalizada = velocidade * Time.deltaTime;

        gameObject.transform.Translate(dir.normalized * velocidadeNormalizada, Space.World);
        Quaternion NovaRotacao = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, NovaRotacao, velocidadeNormalizada * 2f);

        float distancia = Vector3.Distance(transform.position, waypointAtual.Position);
        if (distancia <= C_Jogo.instancia.OfssetInimigo)
        {
            Debug.Log("Encontrou novo Waypoint");
            waypointAtual = waypointAtual.GetNovoWaypoint();
        }
    }

    public void LevarDano(float dano, bool ganharDinheiro, Vector3 Direcao, Vector3 Posicao)
    {
        vidaAtual -= dano;
        LevouDano?.Invoke();
        C_Audio.audio.PlayAudioDano();

        if (Direcao != Vector3.zero)
        {
            Instantiate(ParticulaDano, Posicao,Quaternion.LookRotation(-Direcao));
        }
        StartCoroutine(MudarCor(CorDano, 1f));
        Camera.AdicionarNoise(0.05f, 0.3f);
  
        if (vidaAtual <= 0)
        {
            if (ganharDinheiro)
            {
                C_Fase.instancia.AcidionarDinheiro(DinheiroGanho);
            }
            Morreu?.Invoke(this);
            Destroy(this.gameObject);
            C_Audio.audio.PlayAudioMorte();
        }

    }

    IEnumerator MudarCor(Color cor, float tempo)
    {
        if(gameObject == null)
        {
            yield break;
        }
        Render.materials[MaterialBase].SetColor("_Color", cor);
        //velocidade -= 0.5f;
        yield return tempo;
        Render.materials[MaterialBase].SetColor("_Color", corBase);
        //velocidade += 0.5f;
        Debug.Log("Mudando cor");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Vida")
        {
            Debug.Log("Colediu com vida.");
            C_Audio.audio.PlayAudioDanoJogador();
            AcertouVida.Invoke(dano);
            LevarDano(vidaTotal, false, Vector3.zero, Vector3.zero);
            Camera.AdicionarNoise(1f, 0.3f);
            Render.enabled = false;
            Destroy(this.gameObject,1f);
        }
    }

    public void MudarWaypoint(Waypoint novoWaypoint)
    {
        waypointAtual = novoWaypoint;
    }

    public int GetPosicaoNaFila()
    {
        return posicaoNaFila;
    }

    public void SetarPosicaoNaFila(int novaPosicao)
    {
        posicaoNaFila = novaPosicao;
    }

    
}
