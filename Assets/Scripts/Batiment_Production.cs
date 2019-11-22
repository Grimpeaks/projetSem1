using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Batiment_Production : Interactable
{
    public Button boutonPlus;
    public Button boutonMoins;
    protected int m_nb_serviteur = 0;
    public Text myText;
    protected string m_nb_serviteur_string;
    protected float tpsProd;
    protected float tpsProdDépart;
    protected float mutliplicateur_tps = 0.0f;
    public AudioSource audioSourcePlus;
    public AudioSource audioSourceMoins;
    public AudioSource audioSourceRessource;
    public AudioSource audioSourceErreur;
    public Slider progress;
    public GameObject prefab_serviteur;
    

    protected void Start()
    {
        boutonPlus.onClick.AddListener(OnClickPlus);
        boutonMoins.onClick.AddListener(OnClickMoins);
        progress.maxValue = 100;
        progress.minValue = 0;
        progress.value = 100;
        progress.interactable = false;
       //serviteur.GetComponent<Serviteur>().set_Target(RessourceManager.Instance.get_target(RessourceManager.Target.house));
    }
    public override void interagir(GameObject serviteur) 
    {
        Destroy(serviteur);
    }
    void OnClickPlus()
    {
        audioSourcePlus.Play();
        m_nb_serviteur += 1;
        mutliplicateur_tps += 0.5f;
        RessourceManager.Instance.utiliser_serviteur();
    }
    void OnClickMoins()
    {
        
        if (m_nb_serviteur > 0)
        {
            audioSourceMoins.Play();
            m_nb_serviteur -= 1;
            mutliplicateur_tps -= 0.5f;
            RessourceManager.Instance.utiliser_serviteur(true);          
        }
        if (m_nb_serviteur <= 0)
        {
            audioSourceErreur.Play();
            tpsProd = tpsProdDépart;
            mutliplicateur_tps = 0;
            progress.value = 100;
        }


        //Debug.Log("You have clicked the button Moins! " + tpsProd.ToString());
        //supprimer un serviteur des deux listes
        //Deplacer serviteur jusqu'a la base
    }

    protected void Update()
    {
        DisplayServiteur();
        Produire();

        if (m_nb_serviteur <= 0)
        {
            boutonMoins.interactable = false;
            boutonPlus.interactable = true;
        }
        if (RessourceManager.Instance.get_Nb_Serviteurs_restants() <= 0)
        {
            boutonPlus.interactable = false;
            boutonMoins.interactable = true;
        }
        else { boutonPlus.interactable = true; boutonMoins.interactable = true; }
    }
    void DisplayServiteur()
    {
       myText.text = m_nb_serviteur_string;
        m_nb_serviteur_string = m_nb_serviteur.ToString();
    }

    public abstract void Produire();

  
}
