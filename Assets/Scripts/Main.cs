using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //    Inventaire res = new Inventaire();
        //    res.Ajouter_Material(Inventaire.MaterialRessourceType.Bois);
        //    res.Ajouter_Material(Inventaire.MaterialRessourceType.Roche,10);
        //    res.Suprrimer_Material(Inventaire.MaterialRessourceType.Bois, 4);

        Inventaire.getInstance().Ajouter_Material(Inventaire.MaterialRessourceType.Bois, 5);
        Debug.Log(Inventaire.getInstance().get_Inventaire_Material());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
