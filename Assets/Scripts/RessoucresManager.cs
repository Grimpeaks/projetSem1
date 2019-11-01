using System.Collections.Generic;
using UnityEngine;

public class RessourceManager : Singleton<RessourceManager>
{ 
    private Dictionary<RessourceManager.MaterialRessourceType, float> m_dictionnaire_temps_production = new Dictionary<RessourceManager.MaterialRessourceType, float>();

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
    private CompterRessource m_compter;

    private RessourceManager()
    {
        Debug.Log("Hello");
        List<MaterialRessourceType> list_material = new List<MaterialRessourceType>();
        foreach (MaterialRessourceType type in System.Enum.GetValues(typeof(MaterialRessourceType)))
        {
            list_material.Add(type);
        }

        List<WeaponRessourceType> list_weapon = new List<WeaponRessourceType>();
        foreach (WeaponRessourceType type in System.Enum.GetValues(typeof(WeaponRessourceType)))
        {
            list_weapon.Add(type);
        }
        m_compter = new CompterRessource(list_material, list_weapon);

        m_dictionnaire_temps_production.Add(MaterialRessourceType.Bois, 30f);
        m_dictionnaire_temps_production.Add(MaterialRessourceType.Roche, 50f);
    }

    public void Ajouter_Material(MaterialRessourceType type ,uint nb = 1)
    {
        m_compter.Add_Supp_Material(type, (int)nb);
    }
    public void Ajouter_Weapon(WeaponRessourceType type, uint nb = 1)
    {
        m_compter.Add_Supp_Weapon(type, (int)nb);
    }

    public void Suprrimer_Material(MaterialRessourceType type, uint nb = 1)
    {

        m_compter.Add_Supp_Material(type, (int)nb*-1);
    }

    public void Suprrimer_Weapon(WeaponRessourceType type, uint nb = 1)
    {

        m_compter.Add_Supp_Weapon(type, (int)nb * -1);
    }

    public Dictionary<RessourceManager.MaterialRessourceType, int> get_Inventaire_Material()
    {
        return m_compter.get_Inventaire_Material();

    }
    public Dictionary<RessourceManager.WeaponRessourceType, int> get_Inventaire_Weapon()
    {
        return m_compter.get_Inventaire_Weapon();

    }

    public float get_Temps_Production(MaterialRessourceType type)
    {
        return m_dictionnaire_temps_production[type];
    }
    void Start()
    {

    }

    void Update()
    {


    }
}

