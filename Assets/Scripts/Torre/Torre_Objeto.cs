using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre_Objeto : MonoBehaviour
{
    [SerializeField] Torre TorreAssociada;
    Torre torreUsada;
    public EventoTorre EventoAtual;

    //Selecao
    public List<Renderer> Render = new List<Renderer>();
    public GameObject Cabeca;
  

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

    public Torre GetTorre()
    {
        if(torreUsada == null)
        {
            CriarInstancaiDeTorre();
        }

        return torreUsada;
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
    }


    private void OnDrawGizmos()
    {
        if(torreUsada != null)
        Gizmos.DrawWireSphere(this.transform.position, torreUsada.Raio);
    }

    
}
