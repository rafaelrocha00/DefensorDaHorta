using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDeFase : MonoBehaviour
{
    [SerializeField] GameObject menuPause;
    [SerializeField] GameObject menuOpcoes;
    [SerializeField] GameObject menuDeAviso;
    Stack<GameObject> menusAbertos = new Stack<GameObject>();

    void LidarComInput()
    {
        if (Input.GetButtonDown("Cancel"))
        {

            if (menusAbertos.Count == 0)
            {
                AbrirPause();
            }
            else
            {
                FecharMenu();
            }
        }
    }

    void AbrirMenu(GameObject menu)
    {
        menu.SetActive(true);
        menusAbertos.Push(menu);
        Time.timeScale = 0;
    }

    public void AbrirPause()
    {
        AbrirMenu(menuPause);
    }

    public void AbrirAvisoDeSaida()
    {
        AbrirMenu(menuDeAviso);
    }

    public void AbrirOpcoes()
    {
        AbrirMenu(menuOpcoes);
    }

    public void FecharMenu()
    {
        menusAbertos.Pop().SetActive(false);
        if(menusAbertos.Count == 0)
        {
            Time.timeScale = 1;
        }
    }

    void Update()
    {
        LidarComInput();
    }
}
