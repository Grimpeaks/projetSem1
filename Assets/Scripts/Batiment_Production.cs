using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Batiment_Production : MonoBehaviour
{
    public Button boutonPlus;
    public Button boutonMoins;
    private int m_nb_serviteur = 0;
    //private List<string> serviteurs_ajoutes = new List<string>();
    //private List<string> serviteurs_actifs = new List<string>();
    public Text myText;
    private string m_nb_serviteur_string;
    private float tpsProd;
    private float tpsProdDépart;
    private float mutliplicateur_tps = 0.0f;
    public RessourceManager.MaterialRessourceType type_ressource_produite;
    
    public Slider progress;

    void Start()
    {
        boutonPlus.onClick.AddListener(OnClickPlus);
        boutonMoins.onClick.AddListener(OnClickMoins);
        progress.maxValue = 100;
        progress.minValue = 0;
        progress.value = 100;
        tpsProdDépart = RessourceManager.Instance.get_Temps_Production(type_ressource_produite);
        tpsProd = tpsProdDépart;

    }

    // void Oncollision(){ ajouter serviteur a liste serviteurs_actifs}
    void OnClickPlus()
    {
        m_nb_serviteur += 1;
        mutliplicateur_tps += 0.5f;
        Debug.Log("You have clicked the button Plus! " + tpsProd.ToString());
        //Choisir un serviteur a ajouter dans la liste serviteurs_ajoutes
        //Deplacer serviteur jusqu'au batiment
    }

    void OnClickMoins()
    {
        if (m_nb_serviteur > 0)
        {
            m_nb_serviteur -= 1;
            mutliplicateur_tps -= 0.5f;
            if (m_nb_serviteur <= 0) { tpsProd = tpsProdDépart;
                mutliplicateur_tps = 0;
                progress.value = 100;
            }
        }
        Debug.Log("You have clicked the button Moins! " + tpsProd.ToString());
        //supprimer un serviteur des deux listes
        //Deplacer serviteur jusqu'a la base
    }

    void Update()
    {
        DisplayServiteur();
        Produire();
    }
    void DisplayServiteur()
    {
       myText.text = m_nb_serviteur_string;
        m_nb_serviteur_string = m_nb_serviteur.ToString();
    }

    void Produire()
    {
      tpsProd -= Time.deltaTime*mutliplicateur_tps;
      if (tpsProd <= 0)
      {
         tpsProd = tpsProdDépart;
         RessourceManager.Instance.Ajouter_Material(type_ressource_produite);
         //Un bonhomme va deposer la ressource au depot
      }
        if (tpsProd != tpsProdDépart)
        {
            progress.value = 100 - ((tpsProd / tpsProdDépart) * 100);
        }
    }


}
