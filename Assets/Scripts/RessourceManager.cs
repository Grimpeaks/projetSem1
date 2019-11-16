﻿using System.Collections.Generic;
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
        public uint nb;
        public uint prix;
        public uint puissance;
        public Ressources_necessaire[] ressources_necessaire;
    }


    public Ressource[] ressources;
    public Arme[] armes;
    private int m_max_ressource=15;
    private Dictionary<RessourceManager.MaterialRessourceType, Ressource> m_dictionnaire_ressoucres = new Dictionary<RessourceManager.MaterialRessourceType, Ressource>();
    private Dictionary<RessourceManager.WeaponRessourceType, Arme> m_dictionnaire_armes = new Dictionary<RessourceManager.WeaponRessourceType, Arme>();

    public Dictionary<RessourceManager.WeaponRessourceType, Arme> get_All_Weapon()
    {
        return this.m_dictionnaire_armes;
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

