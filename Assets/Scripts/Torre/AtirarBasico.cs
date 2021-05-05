using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarBasico : MonoBehaviour
{
    Torre_Objeto torre;
    [SerializeField] GameObject PontoDeTiro;

    private void Start()
    {
        torre = GetComponent<Torre_Objeto>();
    }

    public virtual void Atirar(Vector3 Target)
    {
        Projetil projetil = Instantiate(torre.GetProjetil(), PontoDeTiro.transform.position, Quaternion.identity).GetComponent<Projetil>();
        projetil.Target = Target;
        projetil.Dano += torre.GetBonusDeDano();
        projetil.Velocidade += torre.GetBonusDeVelocidade();
    }

    public virtual void PararDeAtirar()
    {

    }
}
