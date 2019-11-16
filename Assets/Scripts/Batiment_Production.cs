using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Batiment_Production : MonoBehaviour
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
    //private AudioSource audioSourceRessource = RessourcesBati;

    public Slider progress;

    protected void Start()
    {
        boutonPlus.onClick.AddListener(OnClickPlus);
        boutonMoins.onClick.AddListener(OnClickMoins);
        progress.maxValue = 100;
        progress.minValue = 0;
        progress.value = 100;
        //mettre ça dans les scripts enfants en fonction du type 
        //tpsProdDépart = RessourceManager.Instance.get_Ressource(type_ressource_produite).temps_producion;
        //tpsProd = tpsProdDépart; 
    }
    void OnClickPlus()
    {
        audioSourcePlus.Play();
        m_nb_serviteur += 1;
        mutliplicateur_tps += 0.5f;
    }
    void OnClickMoins()
    {
        
        if (m_nb_serviteur > 0)
        {
            audioSourceMoins.Play();
            m_nb_serviteur -= 1;
            mutliplicateur_tps -= 0.5f;

            if (m_nb_serviteur <= 0) {
                audioSourceErreur.Play();
                tpsProd = tpsProdDépart;
                mutliplicateur_tps = 0;
                progress.value = 100;
                }
        }
        

        //Debug.Log("You have clicked the button Moins! " + tpsProd.ToString());
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

    //mettre abstract et coder cette fonction dans les script enfants
    public abstract void Produire();

  
}
