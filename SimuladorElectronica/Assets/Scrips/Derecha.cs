using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirDerecha : MonoBehaviour
{
    public Animator Derecha;


    private void OnTriggerEnter(Collider other)
    {
        Derecha.Play("PuertaDerecha");
    }
    private void OnTriggerExit(Collider other)
    {
        Derecha.Play("PuertaDerechaCierra");
    }
}



