using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Craft : MonoBehaviour
{
    public GameObject prefab;
    
    void Start()
    {
        Populate();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Populate()
    {
        GameObject newObj;
        foreach(RessourceManager.WeaponRessourceType weapon in Enum.GetValues(typeof(RessourceManager.WeaponRessourceType)))
        //for(int i =0; i<10;i++)
        {
            if(weapon != RessourceManager.WeaponRessourceType.None)
            {
                newObj = (GameObject)Instantiate(prefab, transform);
                newObj.GetComponent<Button>().image.sprite = RessourceManager.Instance.get_Arme(weapon).image;
                newObj.GetComponent<Button>().GetComponentInChildren<Text>().text = "";
                newObj.GetComponent<Button>().onClick.AddListener(delegate { OnclickArme(weapon); });

            }
        }
    }

    public void OnclickArme(RessourceManager.WeaponRessourceType type)
    {
        Debug.Log(type);

    }
}
