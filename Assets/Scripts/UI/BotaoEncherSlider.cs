using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoEncherSlider : MonoBehaviour
{
    [SerializeField]Slider slider;
    [SerializeField]BotaoTorre torre;
    C_Fase fase;

    private void Start()
    {
        fase = C_Fase.instancia.GetComponent<C_Fase>();
        fase.DinheiroMudou += Atualizar;
        Atualizar();
    }

    public void Atualizar()
    {
        float valor = Mathf.Min(fase.GetDinheiro() / torre.GetPreco(), 1f);
        slider.value = valor;
        if(slider.value == 1f)
        {
            slider.value = 0;
        }
    }
}
