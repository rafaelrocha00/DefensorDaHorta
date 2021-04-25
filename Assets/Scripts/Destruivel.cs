using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Destruivel : MonoBehaviour, Iinteragivel
{
    Renderer render;
    Material materialBase;
    [SerializeField]Material materialSelecionado;
    [SerializeField]GameObject BotaoObjeto;
    GameObject BotaoInstanciado;
    [SerializeField]float Preco;
    [SerializeField]float tempo;
    [SerializeField]GameObject sliderObjeto;
    [SerializeField] Slider slider;

    void Start()
    {
        render = GetComponent<Renderer>();
        materialBase = render.material;
    }

    public void Selecionar(Color cor)
    {
        render.material = materialSelecionado;
        BotaoInstanciado = Instantiate(BotaoObjeto, GameObject.Find("UISpawn").transform);
        BotaoInstanciado.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        BotaoInstanciado.transform.position += new Vector3(0, -0.5f);

        Button Botao = BotaoInstanciado.GetComponent<Button>();
        Botao.onClick.AddListener(DestruirObjeto);
        if(C_Fase.instancia.GetDinheiro() < Preco)
        {
            Botao.enabled = false;
        }
    }

    public void DestruirObjeto()
    {
        if(C_Fase.instancia.GetDinheiro() >= Preco)
        {
            C_Fase.instancia.RetirarDinheiro(Preco);
            Debug.Log("Destruido");
            Destroy(BotaoInstanciado);
            slider = Instantiate(sliderObjeto, GameObject.FindGameObjectWithTag("CanvasAtual").transform).GetComponent<Slider>();
            slider.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            StartCoroutine(Destruir(tempo));
        }
  
    }

    IEnumerator Destruir(float Tempo)
    {
        float Contador = 0;
        slider.maxValue = 1f;
        slider.minValue = 0f;
        while(Contador <= 1f)
        {
            slider.value = Contador;
            Contador += Time.deltaTime/ Tempo;
            yield return null;
        }
        Destroy(slider.gameObject);
        Destroy(gameObject);
    }

    public void Deselecionar()
    {
        if(render != null)
        {
            render.material = materialBase;
            Destroy(BotaoInstanciado);

        }
    }
}
