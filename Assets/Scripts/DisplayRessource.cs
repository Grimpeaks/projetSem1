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
        nb = RessourceManager.Instance.get_Ressource(type).nb.ToString();
        DisplayInfo();
    }

    void DisplayInfo()
    {
        myText.text = nb;
    }

}
