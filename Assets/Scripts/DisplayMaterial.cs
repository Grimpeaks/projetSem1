using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMaterial : DisplayRessource
{
    public RessourceManager.MaterialRessourceType type;

   

    // Update is called once per frame
    protected override void Update()
    {
        nb = RessourceManager.Instance.get_Ressource(type).nb.ToString();
        DisplayInfo();
    }


}
