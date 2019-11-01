using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompterRessource : MonoBehaviour
{
    Dictionary<RessourceManager.MaterialRessourceType, int> m_compter_material= new Dictionary<RessourceManager.MaterialRessourceType, int>();
    Dictionary<RessourceManager.WeaponRessourceType, int> m_compter_weapon = new Dictionary<RessourceManager.WeaponRessourceType, int>();

    public CompterRessource(List<RessourceManager.MaterialRessourceType> list_material, List<RessourceManager.WeaponRessourceType> list_weapon)
    {
        foreach (RessourceManager.MaterialRessourceType type in list_material)
        {
            m_compter_material.Add(type, 0);
        }
        foreach (RessourceManager.WeaponRessourceType type in list_material)
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

    public void Add_Supp_Material(RessourceManager.MaterialRessourceType type, int nb)
    {
        m_compter_material[type] += nb;
    }

    public void Add_Supp_Weapon(RessourceManager.WeaponRessourceType type, int nb)
    {

        m_compter_weapon[type] += nb;
    }

    public Dictionary<RessourceManager.MaterialRessourceType, int> get_Inventaire_Material()
    {
        return m_compter_material;
    }

    public Dictionary<RessourceManager.WeaponRessourceType, int> get_Inventaire_Weapon()
    {
        return m_compter_weapon;
    }
}
