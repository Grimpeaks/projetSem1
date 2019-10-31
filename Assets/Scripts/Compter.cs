using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompterRessource : MonoBehaviour
{
    Dictionary<Inventaire.MaterialRessourceType, int> m_compter_material= new Dictionary<Inventaire.MaterialRessourceType, int>();
    Dictionary<Inventaire.WeaponRessourceType, int> m_compter_weapon = new Dictionary<Inventaire.WeaponRessourceType, int>();

    public CompterRessource(List<Inventaire.MaterialRessourceType> list_material, List<Inventaire.WeaponRessourceType> list_weapon)
    {
        foreach (Inventaire.MaterialRessourceType type in list_material)
        {
            m_compter_material.Add(type, 0);
        }
        foreach (Inventaire.WeaponRessourceType type in list_material)
        {
            m_compter_weapon.Add(type, 0);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Add_Supp_Material(Inventaire.MaterialRessourceType type, int nb)
    {
        m_compter_material[type] += nb;
    }

    public void Add_Supp_Weapon(Inventaire.WeaponRessourceType type, int nb)
    {

        m_compter_weapon[type] += nb;
    }

    public Dictionary<Inventaire.MaterialRessourceType, int> get_Inventaire_Material()
    {
        return m_compter_material;
    }

    public Dictionary<Inventaire.WeaponRessourceType, int> get_Inventaire_Weapon()
    {
        return m_compter_weapon;
    }
}
