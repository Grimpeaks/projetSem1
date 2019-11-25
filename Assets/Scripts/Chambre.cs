using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chambre : Interactable
{
    public Text text_nb_serviteurs;
    public Text text_max_serviteurs;
    public Button bouton_acheter;
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
        bouton_acheter.onClick.AddListener(Acheter_Serviteur);
    }

    public void Acheter_Serviteur()
    {
        RessourceManager.Instance.acheter_serviteur(500);
    }
    
    void Update()
    {
        text_max_serviteurs.text = "Serviteurs total : "+RessourceManager.Instance.get_Max_Serviteurs().ToString();
        text_nb_serviteurs.text = "Serviteurs libres : " + RessourceManager.Instance.get_Nb_Serviteurs_restants().ToString();
        bouton_acheter.interactable = RessourceManager.Instance.get_bourse() >= 500;
    }
}
