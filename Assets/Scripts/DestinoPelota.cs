using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestinoPelota : MonoBehaviour {

    Pelota pelota;
    UtilizaClic clic;
    Personaje personaje;

    private void Start()
    {
        pelota = FindObjectOfType<Pelota>();
        clic = FindObjectOfType<UtilizaClic>();
        personaje = FindObjectOfType<Personaje>();
    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("No es un boton");
            clic.VerificaPosicionClicMouse();
            pelota.Patea(clic.objetivo);
            personaje.SilvatoPenal();
        }
    }
}
