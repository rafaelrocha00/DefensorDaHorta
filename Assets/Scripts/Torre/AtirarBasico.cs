using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensoes;

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
        Debug.Log("Atirando");
        GameObject tiro = Instantiate(torre.GetProjetil(), PontoDeTiro.transform.position, Quaternion.identity);
        IAtiravel projetil = tiro.GetInterface<IAtiravel>();
        projetil.SetarTiro(PontoDeTiro.transform, Target, torre.GetBonusDeDano(), torre.GetBonusDeVelocidade());
    }

    public virtual void PararDeAtirar()
    {

    }
}
