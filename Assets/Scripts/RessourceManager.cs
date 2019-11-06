using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RessourceManager : Singleton<RessourceManager>
{
    [System.Serializable]
    public struct Ressource
    {
        public MaterialRessourceType type;
        public float temps_producion;
        public Sprite image;
        public uint nb;
    }

    public Ressource[] ressources;
    private int m_max_ressource=15;
    private Dictionary<RessourceManager.MaterialRessourceType, Ressource> m_dictionnaire = new Dictionary<RessourceManager.MaterialRessourceType, Ressource>();
    //public Dictionary<RessourceManager.MaterialRessourceType, Sprite> m_dictionnaire_Images;
    public enum MaterialRessourceType 
    {
        Bois,
        Roche
    }
    public enum WeaponRessourceType
    {
        Bois,
        Roche
    }

    public int get_Max_Ressource()
    {
        return m_max_ressource;
    }
    private RessourceManager()
    {
    }
    public void Ajouter_Material(MaterialRessourceType type ,uint nb = 1)
    {
        Ressource r = m_dictionnaire[type];
        r.nb += nb;
        m_dictionnaire.Remove(type);
        m_dictionnaire[type] = r;
    }
    public void Ajouter_Weapon(WeaponRessourceType type, uint nb = 1)
    {
        //Ressource r = m_dictionnaire[type];
        //r.nb += nb;
        //m_dictionnaire.Remove(type);
        //m_dictionnaire[type] = r;
        // m_compter.Add_Supp_Weapon(type, (int)nb);
    }

    public void Suprrimer_Material(MaterialRessourceType type, uint nb = 1)
    {  
        Ressource r = m_dictionnaire[type];
        if (r.nb >= 1)
        {
            r.nb -= nb;
            m_dictionnaire.Remove(type);
            m_dictionnaire[type] = r;
        }
    }

    public void Suprrimer_Weapon(WeaponRessourceType type, uint nb = 1)
    {
        //Ressource r = m_dictionnaire[type];
        //r.nb += nb;
        //m_dictionnaire.Remove(type);
        //m_dictionnaire[type] = r;

        //m_compter.Add_Supp_Weapon(type, (int)nb * -1);
    }
   
    public Ressource get_Ressource(MaterialRessourceType type)
    {
        return m_dictionnaire[type];
    }

    void Start()
    {
        foreach (Ressource ress in ressources)
        {
            m_dictionnaire.Add(ress.type, ress);
        }
    }

    void Update()
    {
    }
}

