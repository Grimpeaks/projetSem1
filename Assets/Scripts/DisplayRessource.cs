using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRessource : MonoBehaviour
{
    string nb;
    public RessourceManager.MaterialRessourceType type;
    public Text myText;
   

    // Start is called before the first frame update
    void Start()
    {
       
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Inventaire.getInstance().Ajouter_Material(Inventaire.MaterialRessourceType.Bois);
        //Inventaire.getInstance().Ajouter_Material(Inventaire.MaterialRessourceType.Bois, 5);
        //Inventaire.getInstance().Suprrimer_Material(Inventaire.MaterialRessourceType.Bois, 2);
        //Dictionary<RessourceManager.MaterialRessourceType, int> dict = RessourceManager.Instance.get_Inventaire_Material();
        nb = RessourceManager.Instance.get_Ressource(type).nb.ToString();
        DisplayInfo();
    }

    void DisplayInfo()
    {
        myText.text = nb;
    }

}
