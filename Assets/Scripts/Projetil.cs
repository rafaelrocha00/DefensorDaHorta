using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public Vector3 Target;
    public Vector3 Dir;
    public float Velocidade;
    public float Dano;
    public float DistanciaMax;
    public float tempoMaxvida;

    private void Start()
    {
        tempoMaxvida = DistanciaMax;
        Dir = Vector3.Normalize(Target - transform.position);

    }

    private void Update()
    {
        float valor = Velocidade * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(this.transform.position, Target, DistanciaMax);
        transform.Translate(Dir*Velocidade*Time.deltaTime);
        tempoMaxvida -= Time.deltaTime;
        if(tempoMaxvida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colediu");
        if(other.tag == "Inimigo")
        {
            Debug.Log("Acertou inimigo");
            Inimigo_Objeto inimigo = other.gameObject.GetComponent<Inimigo_Objeto>();
            inimigo.LevarDano(Dano,true, Dir,transform.position);
            Destroy(this.gameObject);
        }

    

        if (other.gameObject.tag == "Chao" || other.gameObject.tag == "Parede")
        {
            Destroy(gameObject);
        }
    }

     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "TerrenoAcesivo")
        {
            Destroy(gameObject);
        }
    }



}
