using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour {

    [SerializeField] Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.GetComponent<Pelota>()) {

            anim.SetTrigger("Gol");
        }
    }
}
