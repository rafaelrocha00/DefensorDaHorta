using UnityEngine;
using UnityEngine.UI;

public class BotaoIniciarFase : MonoBehaviour
{
    Button waveButao;

    private void Start()
    {
        waveButao = GetComponent<Button>();
        waveButao.onClick.AddListener(Iniciar);
    }

    void Iniciar()
    {
        C_Wave wave = GameObject.FindGameObjectWithTag("Fase").GetComponent<C_Wave>();
        wave.IniciarWaves();
        waveButao.gameObject.SetActive(false);
        Debug.Log("Iniciou");
    }
}
