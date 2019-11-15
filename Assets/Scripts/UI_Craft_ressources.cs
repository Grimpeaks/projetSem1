using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class UI_Craft_ressources : MonoBehaviour
{
    public GameObject prefabImage;
    public GameObject prefabText;
    List<GameObject> liste_prefabs = new List<GameObject>();
    public Text TextBubble;
    public Button boutonAjout;
    public Button boutonEnlever;
    public Text text_nb_to_create;
    
    private RessourceManager.WeaponRessourceType m_type = RessourceManager.WeaponRessourceType.None;
    private int nb_to_create=0;
    private uint max_to_create = 0;

    void Start()
    {
        boutonAjout.interactable = false;
        boutonEnlever.interactable = false;
        boutonAjout.onClick.AddListener(delegate { Set_nb_to_create(); });
        boutonEnlever.onClick.AddListener(delegate { Set_nb_to_create(true); });
    }

    public bool PeutEtreActif(bool btn)
    {
        if (btn)
        {
            return nb_to_create < max_to_create;
        }
        else
        {
            return nb_to_create > 0;
        }
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
    void Update()
    {
       if(m_type!= RessourceManager.WeaponRessourceType.None)
        {
            TextBubble.text = "Vous pouvez créer au maximum " + Calcul_Max_Production() + " " + m_type;
        
            max_to_create = Calcul_Max_Production();
            boutonAjout.interactable = PeutEtreActif(true);
            boutonEnlever.interactable = PeutEtreActif(false);
        }
    }
    void Set_nb_to_create(bool enlever=false)
    {
        int nb=0;
        if (enlever && nb_to_create>0){nb = -1;}
        else if(nb_to_create<max_to_create){ nb = 1; }
        nb_to_create += nb;
        text_nb_to_create.text = nb_to_create.ToString();
    }
    public uint Calcul_Max_Production()
    {
       List<uint> liste_max = new List<uint>();
       RessourceManager.Ressources_necessaire[] ressources_n = RessourceManager.Instance.get_Arme(m_type).ressources_necessaire;
       foreach (RessourceManager.Ressources_necessaire ressource in ressources_n)
        {
            uint nb_in_stock = RessourceManager.Instance.get_Ressource(ressource.type).nb;
            if (nb_in_stock <= 0)
            {
                return 0;
            }
            uint nb = nb_in_stock / ressource.nb ;
            liste_max.Add(nb);
        }
        uint max = liste_max.Min();
        return max;
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
