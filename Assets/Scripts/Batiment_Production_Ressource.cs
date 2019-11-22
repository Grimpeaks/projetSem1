using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Batiment_Production_Ressource : Batiment_Production
{
    public RessourceManager.MaterialRessourceType type_ressource_produite;
    private GameObject depot;

    public override void Produire()
    {
        tpsProd -= Time.deltaTime * mutliplicateur_tps;
        if (tpsProd <= 0)
        {
            tpsProd = tpsProdDépart;
            prefab_serviteur.GetComponent<Serviteur>().init(depot, this.gameObject,prefab_serviteur);
            prefab_serviteur.GetComponentInChildren<Image>().sprite = RessourceManager.Instance.get_Ressource(type_ressource_produite).image;
            Instantiate(prefab_serviteur, new Vector2(transform.position.x, -3.3f), Quaternion.identity);
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
        this.depot = RessourceManager.Instance.get_target(RessourceManager.Instance.get_depot(type_ressource_produite));
    }
}
