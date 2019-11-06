using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Batiment_Production : MonoBehaviour
{
    public Button boutonPlus;
    public Button boutonMoins;
    //public AudioClip RessourcesBati;
    private int m_nb_serviteur = 0;
    public Text myText;
    private string m_nb_serviteur_string;
    private float tpsProd;
    private float tpsProdDépart;
    private float mutliplicateur_tps = 0.0f;
    public RessourceManager.MaterialRessourceType type_ressource_produite;
    private AudioSource audioSourcePlus;
    private AudioSource audioSourceMoins;
    private AudioSource audioSou_Serviteurs;
    //private AudioSource audioSourceRessource = RessourcesBati;

    public Slider progress;

    void Start()
    {
        boutonPlus.onClick.AddListener(OnClickPlus);
        boutonMoins.onClick.AddListener(OnClickMoins);
        progress.maxValue = 100;
        progress.minValue = 0;
        progress.value = 100;
        tpsProdDépart = RessourceManager.Instance.get_Ressource(type_ressource_produite).temps_producion;
        tpsProd = tpsProdDépart;
        audioSourcePlus = boutonPlus.GetComponent<AudioSource>();
        audioSourceMoins = boutonMoins.GetComponent<AudioSource>();
        //audioSou_Serviteurs = GameObject.Find("pancarte_Serviteur").GetComponent<AudioSource>();
    }

    // void Oncollision(){ ajouter serviteur a liste serviteurs_actifs}
    void OnClickPlus()
    {

        audioSourcePlus.Play();
        m_nb_serviteur += 1;
        mutliplicateur_tps += 0.5f;

        Debug.Log("You have clicked the button Plus! " + tpsProd.ToString());
        //Choisir un serviteur a ajouter dans la liste serviteurs_ajoutes
        //Deplacer serviteur jusqu'au batiment
    }

    void OnClickMoins()
    {
        audioSourceMoins.Play();
        if (m_nb_serviteur > 0)
        {
            m_nb_serviteur -= 1;
            mutliplicateur_tps -= 0.5f;

            if (m_nb_serviteur <= 0) {
                tpsProd = tpsProdDépart;
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
            //Debug.Log("petasse" + RessourceManager.Instance.get_Ressource(RessourceManager.MaterialRessourceType.Bois).temps_producion);
         tpsProd = tpsProdDépart;
         RessourceManager.Instance.Ajouter_Material(type_ressource_produite);
            //Un bonhomme va deposer la ressource au depot
           //audioSourceRessource.Play();
      }
        if (tpsProd != tpsProdDépart)
        {
            progress.value = 100 - ((tpsProd / tpsProdDépart) * 100);
        }
    }

  
}
