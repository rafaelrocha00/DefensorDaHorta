using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour, IAtiravel
{
     Vector3 Target;
     Vector3 Dir;
    [SerializeField] float Velocidade;
    [SerializeField] float Dano;
    [SerializeField] float DistanciaMax;
    [SerializeField] float tempoMaxvida;

    private void Start()
    {
        tempoMaxvida = DistanciaMax;
        Dir = Vector3.Normalize(Target - transform.position);
    }

    private void Update()
    {
        float valor = Velocidade * Time.deltaTime;
        transform.Translate(Dir * Velocidade * Time.deltaTime);
        tempoMaxvida -= Time.deltaTime;
        if(tempoMaxvida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetarTiro(Transform origem, Vector3 target, float bonusDano, float bonusVelocidade)
    {
        this.Target = target;
        Dano += bonusDano;
        Velocidade += bonusVelocidade;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Inimigo")
        {
            Inimigo_Objeto inimigo = other.gameObject.GetComponent<Inimigo_Objeto>();
            inimigo.LevarDano(Dano, true, Dir, transform.position);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "TerrenoAcesivo")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Chao")
        {
            Debug.Log("Colediu com cenario");
            Destroy(gameObject);
        }

    }

    public float GetDano()
    {
        return Dano;
    }
}
