﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Inventaire.Instance.Ajouter_Material(Inventaire.MaterialRessourceType.Bois, 10);
      

    }

    // Update is called once per frame
    void Update()
    {
       // Inventaire.Instance.Ajouter_Material(Inventaire.MaterialRessourceType.Bois);

    }
}
