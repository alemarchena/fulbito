using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SilvatoPenal()
    {
        anim.SetTrigger("Derecha1");
    }
}
