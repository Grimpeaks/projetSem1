using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RessourceManager : Singleton<RessourceManager>
{
    public enum MaterialRessourceType
    {
        None,
        Bois,
        Roche,
        Metal
    }
    public enum WeaponRessourceType
    {
        None,
        Lance,
        Epee
    }
    [System.Serializable]
    public struct Ressources_necessaire
    {
        public MaterialRessourceType type;
        public uint nb;

    }

    [System.Serializable]
    public struct Ressource
    {
        public MaterialRessourceType type;
        public float temps_producion;
        public Sprite image;
        public uint nb;
    }
    [System.Serializable]
    public struct Arme
    {
        public WeaponRessourceType type;
        public float temps_producion;
        public Sprite image;
        public Sprite image_UI_Base;
        public Sprite image_UI_Selected;
        public uint nb;
        public uint prix;
        public uint puissance;
        public Ressources_necessaire[] ressources_necessaire;
    }
   
    public enum Target : int
    {
        house = 0,
        mine = 1,
        depotBois = 2,
        depotRoche = 3,
        depotMetal = 4,
        porteHaut = 5,
        porteBas = 6,

    }

    public GameObject[] targets;
    public Ressource[] ressources;
    public Arme[] armes;
    private int m_max_ressource=15;
    private int nb_serviteurs_utilise=0;
    private int nb_Max_serviteurs=15;
    private Dictionary<RessourceManager.MaterialRessourceType, Ressource> m_dictionnaire_ressoucres = new Dictionary<RessourceManager.MaterialRessourceType, Ressource>();
    private Dictionary<RessourceManager.WeaponRessourceType, Arme> m_dictionnaire_armes = new Dictionary<RessourceManager.WeaponRessourceType, Arme>();

    public Dictionary<RessourceManager.WeaponRessourceType, Arme> get_All_Weapon()
    {
        return this.m_dictionnaire_armes;
    }
    public int get_Nb_Serviteurs_restants()
    {
        return nb_Max_serviteurs - nb_serviteurs_utilise;
    }

    public Target get_depot(MaterialRessourceType m)
    {
        Target depot = Target.house;
        switch (m)
        {
            case MaterialRessourceType.Bois:
                depot =Target.depotBois;
                break;
            case MaterialRessourceType.Metal:
                depot = Target.depotMetal;
                break;
            case MaterialRessourceType.Roche:
                depot =Target.depotRoche;
                break;
        }
        return depot;
    }
    public GameObject get_target(Target t)
    {
        return targets[(int)t];
    }
    public void utiliser_serviteur(bool rendre=false)
    {
        int nb = 1;
        if (rendre) { nb = -1; }
        nb_serviteurs_utilise += nb;
    }
    public int get_Max_Ressource()
    {
        return m_max_ressource;
    }
    private RessourceManager()
    {
    }
    public void Ajouter(MaterialRessourceType typeM, uint nb = 1)
    {     
            Ressource r = m_dictionnaire_ressoucres[typeM];
            r.nb += nb;
            m_dictionnaire_ressoucres.Remove(typeM);
            m_dictionnaire_ressoucres[typeM] = r;         
    }
    public void Ajouter(WeaponRessourceType typeA, uint nb = 1)
    {
            Arme r = m_dictionnaire_armes[typeA];
            r.nb += nb;
            m_dictionnaire_armes.Remove(typeA);
            m_dictionnaire_armes[typeA] = r;
    }
    public void Supprimer(MaterialRessourceType typeM, uint nb = 1)
    {
        Ressource r = m_dictionnaire_ressoucres[typeM];
        r.nb -= nb;
        if (r.nb >= 0)
        {
            m_dictionnaire_ressoucres.Remove(typeM);
            m_dictionnaire_ressoucres[typeM] = r;
        }
    }
    public void Supprimer(WeaponRessourceType typeA, uint nb = 1)
    {
        Arme r = m_dictionnaire_armes[typeA];
        r.nb -= nb;
        if (r.nb >= 0)
        {
            m_dictionnaire_armes.Remove(typeA);
            m_dictionnaire_armes[typeA] = r;
        }
       
    }
    public Ressource get_Ressource(MaterialRessourceType type)
    {
        return m_dictionnaire_ressoucres[type];
    }
    public Arme get_Arme(WeaponRessourceType type)
    {
        return m_dictionnaire_armes[type];
    }
    void Start()
    {  
        foreach (Ressource ress in ressources)
        {
            m_dictionnaire_ressoucres.Add(ress.type, ress);
        }

        foreach (Arme ar in armes)
        {
            m_dictionnaire_armes.Add(ar.type, ar);
        }
    }
    void Update()
    {
    }
}

