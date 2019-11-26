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
        chambre = 7,
        forge = 8,
        depotEpee = 9,
        depot_Lance = 10,

    }

    public GameObject[] targets;
    public Ressource[] ressources;
    public Arme[] armes;
    private int m_max_ressource = 30;
    private int nb_serviteurs_utilise = 0;
    private int nb_Max_serviteurs = 15;
    private Dictionary<RessourceManager.MaterialRessourceType, Ressource> m_dictionnaire_ressoucres = new Dictionary<RessourceManager.MaterialRessourceType, Ressource>();
    private Dictionary<RessourceManager.WeaponRessourceType, Arme> m_dictionnaire_armes = new Dictionary<RessourceManager.WeaponRessourceType, Arme>();
    private int Compteur_Ressources;
    private int Compteur_Armes;
    private int bourse=0;
    private bool Is_UI_Craft_Active = false;

    public void set_UI_Craft_Active(bool isActive)
    {
        Is_UI_Craft_Active = isActive;
    }

    public bool get_Is_UI_Craft_Active()
    {
        return this.Is_UI_Craft_Active;
    }
    public int get_bourse()
    {
        return this.bourse;
    }

    public bool acheter_serviteur(int prix)
    {
        if (this.bourse >= prix)
        {
            this.bourse -= prix;
            nb_Max_serviteurs += 1;
            return true;
        }
        return false;
    }

    public void vendre_arme(int prix)
    {
        this.bourse += prix;
    }

    public Dictionary<RessourceManager.WeaponRessourceType, Arme> get_All_Weapon()
    {

        return this.m_dictionnaire_armes;

    }
    public int get_Nb_Serviteurs_restants()
    {
        return nb_Max_serviteurs - nb_serviteurs_utilise;
    }
    public int get_Max_Serviteurs()
    {
        return nb_Max_serviteurs;
    }

    public Target get_depot(MaterialRessourceType m)
    {
        Target depot = Target.house;
        switch (m)
        {
            case MaterialRessourceType.Bois:
                depot = Target.depotBois;
                break;
            case MaterialRessourceType.Metal:
                depot = Target.depotMetal;
                break;
            case MaterialRessourceType.Roche:
                depot = Target.depotRoche;
                break;
        }
        return depot;
    }

    public Target get_depot(WeaponRessourceType m)
    {
        Target depot = Target.house;
        switch (m)
        {
            case WeaponRessourceType.Epee:
                depot = Target.depotEpee;
                break;
            case WeaponRessourceType.Lance:
                depot = Target.depot_Lance;
                break;
        }
        return depot;
    }
    public GameObject get_target(Target t)
    {
        return targets[(int)t];
    }
    public void utiliser_serviteur(bool rendre = false)
    {
        int nb = 1;
        if (rendre) { nb = -1; }
        nb_serviteurs_utilise += nb;
    }


    public Boolean max_ressource_atteint()
    {
        if (m_max_ressource >= Compteur_Ressources) { return true; }
        else { return false; }
    }

    public Boolean max_armes_atteint()
    {
        if (Compteur_Armes >= m_max_ressource) { return true; }
        else { return false; }
    }

    private RessourceManager()
    {
    }

    public Boolean Ajouter(MaterialRessourceType typeM, uint nb = 1)
    {     
        if(max_ressource_atteint()== false)
        {
            Ressource r = m_dictionnaire_ressoucres[typeM];
            r.nb += nb;
            m_dictionnaire_ressoucres.Remove(typeM);
            m_dictionnaire_ressoucres[typeM] = r;
            Compteur_Ressources += 1;

            return true;
        }
        else { return false; }

    }
    public Boolean Ajouter(WeaponRessourceType typeA, uint nb = 1)
    {
        if (max_armes_atteint() == false)
        {
            Arme r = m_dictionnaire_armes[typeA];
            r.nb += nb;
            m_dictionnaire_armes.Remove(typeA);
            m_dictionnaire_armes[typeA] = r;
            Compteur_Armes += 1;

            return true;
        }
        else { return false; }

    }
    public Boolean Supprimer(MaterialRessourceType typeM, uint nb = 1)
    {
        Ressource r = m_dictionnaire_ressoucres[typeM];
        r.nb -= nb;
        if (r.nb >= 0)
        {
            m_dictionnaire_ressoucres.Remove(typeM);
            m_dictionnaire_ressoucres[typeM] = r;

            return true;
        }
        else { return false; }
        Compteur_Ressources -= 1;

    }
    public Boolean Supprimer(WeaponRessourceType typeA, uint nb = 1)
    {
        Arme r = m_dictionnaire_armes[typeA];
        r.nb -= nb;
        if (r.nb >= 0)
        {
            m_dictionnaire_armes.Remove(typeA);
            m_dictionnaire_armes[typeA] = r;

            return true;
        }
        else { return false; }
        Compteur_Armes -= 1;

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
        if (Input.GetButtonDown("SheetRessources"))
        {
            foreach (MaterialRessourceType res in Enum.GetValues(typeof(MaterialRessourceType)))
            {
                if (res != MaterialRessourceType.None)
                {
                    Ajouter(res, 999);
                }
            }

            foreach (WeaponRessourceType weap in Enum.GetValues(typeof(WeaponRessourceType)))
            {
                if (weap != WeaponRessourceType.None)
                {
                    Ajouter(weap, 999);
                }
            }
        }
    }
}

