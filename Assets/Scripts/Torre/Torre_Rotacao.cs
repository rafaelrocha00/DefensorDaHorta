using System;
using System.Collections;
using UnityEngine;

public class Torre_Rotacao : MonoBehaviour
{
    public void Olhar(Torre_Objeto objetoAtuante, Transform PosicaoInimigo)
    {
        Transform Objeto = objetoAtuante.GetCabeca().transform;

        Vector3 Direcao = (PosicaoInimigo.position - Objeto.position).normalized;
        Direcao.y = 0f;
        Quaternion RotacaoLook = Quaternion.LookRotation(Direcao);
        Objeto.rotation = Quaternion.Slerp(Objeto.rotation, RotacaoLook, Time.deltaTime * 5f);
    }

    public IEnumerator PararDeOlhar(Transform cabeca, Quaternion atual, Quaternion natural, Action depois)
    {
        float contador = 0;
        while (contador < 1f)
        {
            cabeca.rotation = Quaternion.Lerp(atual, natural, contador);
            contador += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        depois?.Invoke();
    }
}
