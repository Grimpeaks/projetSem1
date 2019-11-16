﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batiment_Production_Ressource : Batiment_Production
{
    public RessourceManager.MaterialRessourceType type_ressource_produite;

    public override void Produire()
    {
        tpsProd -= Time.deltaTime * mutliplicateur_tps;
        if (tpsProd <= 0)
        {
            tpsProd = tpsProdDépart;
            RessourceManager.Instance.Ajouter(type_ressource_produite);
            audioSourceRessource.Play();
        }
        if (tpsProd != tpsProdDépart)
        {
            progress.value = 100 - ((tpsProd / tpsProdDépart) * 100);
        }
    }


    
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        tpsProdDépart = RessourceManager.Instance.get_Ressource(type_ressource_produite).temps_producion;
        tpsProd = tpsProdDépart;
    }
}