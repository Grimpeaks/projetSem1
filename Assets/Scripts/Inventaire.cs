using System.Collections.Generic;
using UnityEngine;

public class Inventaire : Singleton<Inventaire>
{ 
   // public static Inventaire inv = null;

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

    private Inventaire()
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

    public Dictionary<Inventaire.MaterialRessourceType, int> get_Inventaire_Material()
    {
        return m_compter.get_Inventaire_Material();

    }
    public Dictionary<Inventaire.WeaponRessourceType, int> get_Inventaire_Weapon()
    {
        return m_compter.get_Inventaire_Weapon();

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
}

