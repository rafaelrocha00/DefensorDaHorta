using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Torre_Objeto : MonoBehaviour
{
    [SerializeField] Torre TorreAssociada;
    [SerializeField] Animator anim;
    Torre torreUsada;
    public EventoTorre EventoAtual;

    //Selecao
    public List<Renderer> Render = new List<Renderer>();
    [SerializeField] Transform Rotacao;

    [SerializeField] List<Evolucao> evolucoesIniciais = new List<Evolucao>();
    float bonusDeDano;
    float bonusDeAlcance;
    float bonusDeVelocidade;
    float bonusDeRecarga;

    public Action<Evolucao> EvolucaoAdicionada;

    [SerializeField]private GameObject PontoDeTiro;


    private void Start()
    {
        if (torreUsada == null)
        {
            CriarInstancaiDeTorre();
        }
    }

    void CriarInstancaiDeTorre()
    {
        torreUsada = (Torre)ScriptableObject.CreateInstance(typeof(Torre));
        torreUsada.Bala = TorreAssociada.Bala;
        torreUsada.Raio = TorreAssociada.Raio;
        torreUsada.TempoDeRecarga = TorreAssociada.TempoDeRecarga;
        torreUsada.Bala = TorreAssociada.Bala;
    }

    private void Update()
    {
        if ((EventoAtual != null)&&(EventoAtual.Checar(this)))
        {
            EventoAtual.Agir(this);
        }
    }

    public void Atirar(Vector3 Target)
    {
        Projetil projetil = Instantiate(torreUsada.Bala, PontoDeTiro.transform.position, Quaternion.identity).GetComponent<Projetil>();
        projetil.Target = Target;
        projetil.Dano += bonusDeDano;
        projetil.Velocidade += bonusDeVelocidade;
    }


    private void OnDrawGizmos()
    {
        if(torreUsada != null)
        Gizmos.DrawWireSphere(this.transform.position, torreUsada.Raio);
    }

    public void ChecarTorre()
    {
        if (torreUsada == null)
        {
            CriarInstancaiDeTorre();
        }
    }

    public float GetRaio()
    {
        ChecarTorre();
        return torreUsada.Raio + bonusDeAlcance;
    }

    public float GetTempoDeRecarga()
    {
        ChecarTorre();
        return torreUsada.TempoDeRecarga + bonusDeRecarga;
    }

    public float GetDano()
    {
        ChecarTorre();
        return torreUsada.GetDano() + bonusDeDano;
    }

    public void AumentarDano(float bonus)
    {
        bonusDeDano += bonus;
    }

    public void AumentarAlcance(float bonus)
    {
        Debug.LogWarning("Aumentando alcance");
        bonusDeAlcance += bonus;
    }

    public void AumentarBonusDeRecarga(float bonus)
    {
        bonusDeRecarga += bonus;
    }

    public void AumentarVelocidade(float bonus)
    {
        bonusDeVelocidade += bonus;
    }

    public Evolucao GetEvolucao(int index)
    {
        evolucoesIniciais[index].SetarTorreAEvoluir(this);
        return evolucoesIniciais[index];
    }
    
    public int GetQuantidadeDeEvolucoes()
    {
        return evolucoesIniciais.Count;
    }

    public void AdicionarEvolucao(Evolucao evolucao)
    {
        evolucoesIniciais.Add(evolucao);
        EvolucaoAdicionada?.Invoke(evolucao);
    }

    public void RetirarEvolucao(Evolucao evolucao)
    {
        evolucoesIniciais.Remove(evolucao);
    }

    public void PararAnimacao()
    {
        anim.SetBool("Atirando", true);
        anim.enabled = false;
    }

    public void VoltarAnimacao()
    {
        anim.enabled = true;
        anim.SetBool("Atirando", false);
    }

    public Transform GetCabeca()
    {
        return Rotacao;
    }


}
