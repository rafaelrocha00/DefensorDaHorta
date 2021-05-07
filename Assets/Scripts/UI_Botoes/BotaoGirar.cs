using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotaoGirar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float angulo;


    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.Rotate(0, 0, angulo);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.Rotate(0, 0, -angulo);

    }
}
