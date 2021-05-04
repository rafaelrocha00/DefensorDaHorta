using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressaoAnimada : MonoBehaviour
{
    [SerializeField] MeshRenderer expressao;
    [SerializeField] float duracaoDeCadaExpressao = 0.3f;
    [SerializeField] float tempoEntreExpressoes = 0.03f;
    [SerializeField] float tempoAteDesfazerExpressao = 0f;
    [SerializeField] Vector2 inicioDaExpressao;
    [SerializeField] Vector2 finalDaExpressao;
    float indexX;
    bool direcaoInversa = false;
    

    private void OnEnable()
    {
        indexX = inicioDaExpressao.x;
        StartCoroutine(AnimarExpressao());
    }

    IEnumerator AnimarExpressao()
    {
        while (true)
        {
            if (indexX > finalDaExpressao.x)
            {
                direcaoInversa = true;
                yield return new WaitForSeconds(tempoAteDesfazerExpressao);
            }

            if (indexX < 0)
            {
                indexX = inicioDaExpressao.x;
                direcaoInversa = false;
                yield return new WaitForSeconds(tempoEntreExpressoes);
            }


            expressao.material.SetFloat("_ColunaDesejada", indexX);
            yield return new WaitForSeconds(duracaoDeCadaExpressao);

            if (direcaoInversa)
            {
                indexX--;
            }
            else
            {
                indexX++;
            }

        }
    }
}
