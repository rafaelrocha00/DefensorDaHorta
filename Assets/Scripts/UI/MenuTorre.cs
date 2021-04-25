using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuTorre : MonoBehaviour
{
    GameObject TorreAtual;
    [SerializeField]Transform PontoDeSpawn;
    [SerializeField] TextMeshProUGUI DescricaoArea;


    public void MudarTorreAtual(GameObject NovaTorre, string TextoDescricao)
    {
        ApagarTorreAntiga();
        TorreAtual = Instantiate(NovaTorre, PontoDeSpawn.position, PontoDeSpawn.rotation);
        DescricaoArea.text = TextoDescricao;
    }

    public void ApagarTorreAntiga()
    {
        if (TorreAtual != null)
            Destroy(TorreAtual);
    }

}
