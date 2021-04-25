using UnityEngine;

public class VoltarComTecla : MonoBehaviour
{
    [SerializeField] string cena;
    [SerializeField] GameObject FadeInBlack;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TransicaoEditor Editor = Camera.main.gameObject.GetComponent<TransicaoEditor>();
            Editor.IniciarTransicaoFadeIN(FadeInBlack, Voltar);
        }
    }

    public void Voltar()
    {
        Time.timeScale = 1;
        C_Jogo.instancia.MudarCena(cena);
    }
}
