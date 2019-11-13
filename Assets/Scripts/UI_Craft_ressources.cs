using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Craft_ressources : MonoBehaviour
{
    public GameObject prefabImage;
    public GameObject prefabText;
    List<GameObject> liste_prefabs = new List<GameObject>();
    private RessourceManager.WeaponRessourceType m_type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Afficher_Ressources_Necessaires(RessourceManager.WeaponRessourceType type)
    {
        this.m_type = type;
        clear();
        Populate();
    }

    public void clear()
    {
        foreach(GameObject g in liste_prefabs)
        {
            Destroy(g);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Populate()
    {
        GameObject newObjImage;
        GameObject newObjText;
        RessourceManager.Ressources_necessaire[] ressources_n = RessourceManager.Instance.get_Arme(m_type).ressources_necessaire;
        List<RessourceManager.Ressources_necessaire> list = new List<RessourceManager.Ressources_necessaire>(ressources_n);
        foreach (RessourceManager.Ressources_necessaire material in ressources_n)
        {
            newObjText = (GameObject)Instantiate(prefabText, transform);
            string s = " " + material.nb + " x";
            if (list.IndexOf(material) > 0)
            {
                s = "+"+s;
            }
            newObjText.GetComponent<Text>().text = s;
            liste_prefabs.Add(newObjText);
            newObjImage = (GameObject)Instantiate(prefabImage, transform);
            newObjImage.GetComponent<Image>().sprite = RessourceManager.Instance.get_Ressource(material.type).image;
            liste_prefabs.Add(newObjImage);            
        }
    }
}
