using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Inimigo : MonoBehaviour
{
    Inimigo_Objeto inimigo;
    Slider slider;
    public GameObject BarradeVida;
    

    private void Start()
    {
        slider = Instantiate(BarradeVida, GameObject.Find("UISpawn").transform).GetComponent<Slider>();
        slider.gameObject.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        inimigo = gameObject.GetComponent<Inimigo_Objeto>();
        slider.maxValue = inimigo.vidaTotal;
        slider.value = inimigo.vidaAtual;
        inimigo.LevouDano += AtualizarSlider;
        slider.gameObject.SetActive(false);

    }

    private void Update()
    {
        if(slider != null)
        slider.gameObject.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position + new Vector3(0,0.5f));     
    }

    public void AtualizarSlider()
    {
        slider.value = inimigo.vidaAtual;
        if(inimigo.vidaAtual <= 0)
        {
            DestruirSlider();
        }
        if(inimigo.vidaAtual != inimigo.vidaTotal)
        {
            slider.gameObject.SetActive(true);
        }
    }

    public void DestruirSlider()
    {
        Destroy(slider.gameObject);
    }
}
