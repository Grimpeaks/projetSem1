using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Batiment_Production_Arme : Batiment_Production
{
    public AudioSource audioSourceCreer;
    public Button boutonProduction;
    public Canvas UICraft;
    

    private RessourceManager.WeaponRessourceType m_type_ressource_produite = RessourceManager.WeaponRessourceType.None;
    private int nb_to_create =0;


    public uint Calcul_Max_Production(RessourceManager.WeaponRessourceType type)
    {
        List<uint> liste_max = new List<uint>();
        RessourceManager.Ressources_necessaire[] ressources_n = RessourceManager.Instance.get_Arme(type).ressources_necessaire;
        foreach (RessourceManager.Ressources_necessaire ressource in ressources_n)
        {
            uint nb_in_stock = RessourceManager.Instance.get_Ressource(ressource.type).nb;
            if (nb_in_stock <= 0)
            {
                return 0;
            }
            uint nb = nb_in_stock / ressource.nb;
            liste_max.Add(nb);
        }
        uint max = liste_max.Min();
        return max;
    }
    public override void Produire()
    {
        if (m_type_ressource_produite != RessourceManager.WeaponRessourceType.None)
        {
            if (nb_to_create!=0) { 
                tpsProd -= Time.deltaTime * mutliplicateur_tps;       
                if (tpsProd <= 0)
                {
                    tpsProd = tpsProdDépart;
                    RessourceManager.Instance.Ajouter(m_type_ressource_produite);
                    nb_to_create -= 1;
                    audioSourceRessource.Play();
                }
                if (tpsProd != tpsProdDépart)
                {
                    progress.value = 100 - ((tpsProd / tpsProdDépart) * 100);
                }
            }
        }
    }

    public void set_Production(RessourceManager.WeaponRessourceType type, int nb)
    {
        if (nb_to_create <= 0)
        {
            m_type_ressource_produite = type;
            nb_to_create = nb;
            tpsProdDépart = RessourceManager.Instance.get_Arme(m_type_ressource_produite).temps_producion;
            tpsProd = tpsProdDépart;
            //this.progress.GetComponentInChildren<Image>().sprite = RessourceManager.Instance.get_Arme(type).image;
            Image[] images = progress.GetComponentsInChildren<Image>();
            for(int i =0; i<images.Length; i++)
            {
                images[i].sprite = RessourceManager.Instance.get_Arme(type).image;
                if (i == 0)
                {
                    images[i].color =new Color(0.235f, 0.235f, 0.235f);
                }
            }
        }     
    }
    new void Update()
    {
        base.Update();
        if (nb_to_create <= 0)
        {
            boutonProduction.interactable = true;
        }
        else { boutonProduction.interactable = false; }
    }
    new void Start()
    {
        base.Start();
        boutonProduction.onClick.AddListener(open);
    }

    public void open()
    {
        audioSourceCreer.Play();
        UICraft.gameObject.SetActive(true);
    }

}
