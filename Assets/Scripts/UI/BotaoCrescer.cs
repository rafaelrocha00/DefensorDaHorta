using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotaoCrescer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] float porcentagemCrescimento;
    Vector3 escalaOriginal;
    [SerializeField]bool voltarAoTamanhoOriginal;

    private void Start()
    {
        escalaOriginal = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = escalaOriginal + (Vector3.one * (porcentagemCrescimento / 100f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = escalaOriginal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(MudarTamanhoAoClicar());
    }

    IEnumerator MudarTamanhoAoClicar()
    {
        transform.localScale = escalaOriginal + (Vector3.one * (porcentagemCrescimento * 2f / 100f));
        yield return new WaitForSeconds(0.1f);
        transform.localScale = escalaOriginal + (Vector3.one * (porcentagemCrescimento / 100f));
        if (voltarAoTamanhoOriginal)
        {
            yield return new WaitForSeconds(0.1f);
            transform.localScale = escalaOriginal;
        }
    }

}
