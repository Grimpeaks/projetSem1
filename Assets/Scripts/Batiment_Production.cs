using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Batiment_Production : MonoBehaviour
{
    public Button boutonPlus;
    public Button boutonMoins;
    private int m_nb_serviteur = 0;
    public Text myText;
    public string myString;
    public float tpsProd = 30;
    public float tpsProdDépart = 30;

    void Start()
    {
        boutonPlus.onClick.AddListener(OnClickPlus);
        boutonMoins.onClick.AddListener(OnClickMoins);
    }

    void OnClickPlus()
    {
        m_nb_serviteur += 1;
        Debug.Log("You have clicked the button Plus! " + m_nb_serviteur.ToString());
        //Deplacer serviteur jusqu'au batiment
    }

    void OnClickMoins()
    {
        if (m_nb_serviteur > 0)
        {
            m_nb_serviteur -= 1;
        }
        Debug.Log("You have clicked the button Moins! " + m_nb_serviteur.ToString());
        //Deplacer serviteur jusqu'a la base
    }

    void Update()
    {
        DisplayServiteur();
        TimerProd();



    }

    void DisplayServiteur()
    {
       myText.text = myString;
       myString = m_nb_serviteur.ToString();
    }

    void TimerProd()
    {
        if (m_nb_serviteur >= 1)
        {
            while (tpsProd > 1) { tpsProd -= Time.deltaTime; }
        }

        else
        {
            tpsProd = tpsProdDépart;
        }
    }


}
