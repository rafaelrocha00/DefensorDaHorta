using System;
using UnityEngine;

public class C_Fase : MonoBehaviour
{
    [SerializeField] float vidas;
    [SerializeField] float dinheiro;

    public Action VidaMudou;
    public Action Perdeu;
    public Action DinheiroMudou;
    public Action<Torre_Objeto> TorreSelecionada;
    public static C_Fase instancia;

    public string nomeDaFase;
    public string nomeDaProximaFase;


    private void Awake()
    {
        if ((instancia != this) && (instancia != null))
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instancia = this;
        }
    }

    public void Inicializar(float vida, float dinheiro)
    {
        this.vidas = vida;
        this.dinheiro = dinheiro;
    }

    public void RetirarVida(float dano)
    {
        vidas -= dano;
        VidaMudou?.Invoke();
        if (vidas <= 0)
        {
            Perdeu?.Invoke();
        }
    }

    public bool RetirarDinheiro(float dinheiro)
    {
        if (this.dinheiro - dinheiro < 0)
        {
            return false;
        }
        else
        {
            this.dinheiro -= dinheiro;
            DinheiroMudou?.Invoke();
            return true;
        }
    }

    public void AcidionarDinheiro(float dinheiro)
    {
        this.dinheiro += dinheiro;
        DinheiroMudou?.Invoke();
    }


    public float GetDinheiro()
    {
        return dinheiro;
    }

    public float GetVida()
    {
        return vidas;
    }

    

   

}
