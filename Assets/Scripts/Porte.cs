using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : Interactable
{
    Animator anim;
    public GameObject destination;

    public override void interagir(GameObject serviteur)
    {
        anim.SetBool("ouvert", true);
        serviteur.GetComponent<Serviteur>().ouvrirPorte(destination);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
