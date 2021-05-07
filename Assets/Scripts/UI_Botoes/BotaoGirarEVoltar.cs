using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotaoGirarEVoltar : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] float angulo;
    [SerializeField] float tempoAteVoltar = 1f;
    [SerializeField] float velocidade = 2f;
    Quaternion rotacaoFinal;
    Quaternion rotacaoOriginal;

    private void Start()
    {
        rotacaoFinal = transform.rotation * Quaternion.Euler(0, 0, angulo);
        rotacaoOriginal = transform.rotation;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(Girar());
    }

 

    IEnumerator Girar(int direcao = 1)
    {
        float contador = 0;
        while(contador < angulo)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacaoFinal, contador);
            contador += Time.deltaTime * velocidade;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(tempoAteVoltar);

        contador = 0f;
        while (contador < angulo)
        {
            transform.rotation = Quaternion.Lerp(rotacaoFinal, rotacaoOriginal, contador);
            contador += Time.deltaTime * velocidade;
            yield return new WaitForEndOfFrame();
        }

    }
}
