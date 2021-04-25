using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpcoes : MonoBehaviour
{
    [SerializeField]GameObject MenuAudio;
    [SerializeField]GameObject MenuArte;

    [SerializeField] Toggle ToggleAudio;
    [SerializeField] Toggle ToggleArte;

    private void Start()
    {
        ToggleAudio.onValueChanged.AddListener(AbrirMenuAudio);
        ToggleArte.onValueChanged.AddListener(AbrirMenuArte);
    }

    public void AbrirMenuArte(bool Resultado)
    {
        MenuArte.SetActive(Resultado);
        MenuAudio.SetActive(!Resultado);
    }

    public void AbrirMenuAudio(bool Resultado)
    {
        MenuAudio.SetActive(Resultado);
        MenuArte.SetActive(!Resultado);
    }

}
