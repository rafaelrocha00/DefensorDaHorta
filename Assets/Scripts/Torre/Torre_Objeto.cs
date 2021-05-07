using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Torre_Objeto : MonoBehaviour
{
    [SerializeField] Torre TorreAssociada;
    Torre torreUsada;

    //Selecao
    public List<Renderer> Render = new List<Renderer>();
    [SerializeField] Transform Rotacao;

    float bonusDeDano;
    float bonusDeAlcance;
    float bonusDeVelocidade;
    float bonusDeRecarga;


    private void Start()
    {
        ChecarTorre();
    }

    void CriarInstanciaDeTorre()
    {
        torreUsada = (Torre)ScriptableObject.CreateInstance(typeof(Torre));
        torreUsada.Bala = TorreAssociada.Bala;
        torreUsada.Raio = TorreAssociada.Raio;
        torreUsada.TempoDeRecarga = TorreAssociada.TempoDeRecarga;
        torreUsada.Bala = TorreAssociada.Bala;
    }

    public GameObject GetProjetil()
    {
        return torreUsada.Bala;
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
            CriarInstanciaDeTorre();
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

    public float GetBonusDeVelocidade()
    {
        return bonusDeVelocidade;
    }

    public float GetBonusDeDano()
    {
        return bonusDeDano;
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

    public Transform GetCabeca()
    {
        return Rotacao;
    }
}
