using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWeapon : DisplayRessource
{

    public RessourceManager.WeaponRessourceType type;

    protected override void Update()
    {
        nb = RessourceManager.Instance.get_Arme(type).nb.ToString();
        DisplayInfo();
    }
}
