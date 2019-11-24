using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chambre : Interactable
{
    public override void interagir(GameObject serviteur)
    {
        StartCoroutine("interagir_Coroutine", serviteur);

    }

    IEnumerator interagir_Coroutine(GameObject serviteur)
    {
        serviteur.GetComponent<Serviteur>().disparaitre();
        yield return new WaitForSeconds(2f);
        Destroy(serviteur);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
