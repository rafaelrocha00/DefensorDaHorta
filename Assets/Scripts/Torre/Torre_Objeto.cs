using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre_Objeto : MonoBehaviour, Iinteragivel
{
    public Torre TorreAssociada;
    public EventoTorre EventoAtual;

    //Selecao
    public List<Renderer> Render = new List<Renderer>();
    public GameObject Cabeca;
    public List<Renderer> AfetadosPelaSelecao = new List<Renderer>();
    [SerializeField]public Material materialSelecionado;
    public Material materialBase;

    [SerializeField]private GameObject PontoDeTiro;

    private void Update()
    {
        if ((EventoAtual != null)&&(EventoAtual.Checar(this)))
        {
            EventoAtual.Agir(this);
        }
    }

    public void Atirar(Vector3 Target)
    {
        Projetil projetil = Instantiate(TorreAssociada.Bala, PontoDeTiro.transform.position, Quaternion.identity).GetComponent<Projetil>();
        projetil.Target = Target;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, TorreAssociada.Raio);
    }

    public void Selecionar(Color corSelecao)
    {
        Debug.Log("Selecionado");
        for (int i = 0; i < AfetadosPelaSelecao.Count; i++)
        {
            AfetadosPelaSelecao[i].material = materialSelecionado;
        }
    }

    public void Deselecionar()
    {
        for (int i = 0; i < AfetadosPelaSelecao.Count; i++)
        {
            AfetadosPelaSelecao[i].material = materialBase;
        }
    }

}
