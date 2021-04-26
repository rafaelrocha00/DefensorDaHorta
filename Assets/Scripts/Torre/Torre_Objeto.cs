using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre_Objeto : MonoBehaviour
{
    public Torre TorreAssociada;
    Torre torreUsada;
    public EventoTorre EventoAtual;

    //Selecao
    public List<Renderer> Render = new List<Renderer>();
    public GameObject Cabeca;
  

    [SerializeField]private GameObject PontoDeTiro;


    private void Start()
    {
        torreUsada = (Torre)ScriptableObject.CreateInstance(typeof(Torre));
        torreUsada.Bala = TorreAssociada.Bala;
        torreUsada.Raio = TorreAssociada.Raio;
        torreUsada.TempoDeRecarga = TorreAssociada.TempoDeRecarga;
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
        Gizmos.DrawWireSphere(this.transform.position, torreUsada.Raio);
    }

    

}
