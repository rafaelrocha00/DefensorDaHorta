using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laser : MonoBehaviour, IAtiravel
{
    [SerializeField] GameObject laserCorpo;
    [SerializeField] float tamanho;
    [SerializeField] float dano;
    Vector3 InicialPos;
    Vector3 dir;

    private void Start()
    {
        InicialPos = laserCorpo.transform.position;
    }


    private void Update()
    {
        laserCorpo.transform.localScale = new Vector3(tamanho, transform.localScale.y, transform.localScale.z);
        laserCorpo.transform.position = InicialPos + new Vector3(tamanho / 2, 0, 0);
        transform.rotation *= Quaternion.LookRotation(dir, Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            Inimigo_Objeto inimigo = other.gameObject.GetComponent<Inimigo_Objeto>();
            inimigo.LevarDano(dano, true, dir, other.ClosestPoint(InicialPos));
        }
    }

    public void SetarTiro(Transform origem, Vector3 target, float bonusDano, float bonusVelocidade)
    {
        dir = origem.forward;
        dano += bonusDano;
    }

    public float GetDano()
    {
        return dano;
    }
}
