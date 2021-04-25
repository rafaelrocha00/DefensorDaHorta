using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particula : MonoBehaviour
{
    public int tempo;
    void Start()
    {
        Destroy(gameObject, tempo);
    }


}
