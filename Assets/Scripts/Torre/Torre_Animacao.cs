using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre_Animacao : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PararAnimacao()
    {
        anim.SetBool("Atirando", true);
        anim.enabled = false;
    }

    public void VoltarAnimacao()
    {
        anim.enabled = true;
        anim.SetBool("Atirando", false);
    }
}
