using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AbrirIzquirda : MonoBehaviour
    {
        public Animator Izquierda;

        private void OnTriggerEnter(Collider other)
        {
            Izquierda.Play("PuertaIzquierda");
        }
        private void OnTriggerExit(Collider other)
        {
            Izquierda.Play("PuertaIzquierdaCierra");
        }
}



