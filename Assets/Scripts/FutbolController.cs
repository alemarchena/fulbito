using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FutbolController : MonoBehaviour {

    [SerializeField] Transform centroTiro;
    [SerializeField] Transform pelota;
    public void PonerPelota() {
        pelota.position = centroTiro.position;
        pelota.GetComponent<Rigidbody>().isKinematic = true;
    }
}
