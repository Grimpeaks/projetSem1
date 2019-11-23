﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Sell_Weapon : MonoBehaviour
{
    public GameObject prefab;
    public GameObject UI;
    public Button close;

    void Start()
    {
        Populate();
        close.onClick.AddListener(OnclickClose);
        Canvas c = GetComponentInParent<Canvas>();
        c.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Populate()
    {
        GameObject newObj;
        foreach (RessourceManager.WeaponRessourceType weapon in Enum.GetValues(typeof(RessourceManager.WeaponRessourceType)))
        {
            if (weapon != RessourceManager.WeaponRessourceType.None)
            {
                RessourceManager.Arme arme = RessourceManager.Instance.get_Arme(weapon);
                newObj = (GameObject)Instantiate(prefab, transform);
                newObj.GetComponent<Button>().image.sprite = arme.image_UI_Base;
                newObj.GetComponent<Button>().GetComponentInChildren<Text>().text = "";
                newObj.GetComponent<Button>().onClick.AddListener(delegate { OnclickArme(weapon); });
                SpriteState s = new SpriteState();
                s.selectedSprite = arme.image_UI_Selected;
                newObj.GetComponent<Button>().spriteState = s;

            }
        }
    }

    public void OnclickArme(RessourceManager.WeaponRessourceType type)
    {
        UI.GetComponentInChildren<UI_Sell_Ressources>().SetWeaponToSell(type);
    }

    public void OnclickClose()
    {
        Canvas c = GetComponentInParent<Canvas>();
        c.gameObject.SetActive(false);
    }
}