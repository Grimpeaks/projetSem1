using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Serviteur : MonoBehaviour
{
    public float speed;
    public GameObject target;
    Animator animator;
    public GameObject serviteur;
    public GameObject origin;
    public RessourceManager.MaterialRessourceType type;
    bool Isobjectif_atteint = false;
    
    public Serviteur()
    {
    }

    public void init(GameObject t,GameObject origin,GameObject serviteur)
    {
        target = t;
        this.serviteur = serviteur;
        this.origin = origin;
    }

    public void retour()
    {
        GameObject tmp = origin;
        origin = target;
        target = tmp;
        Isobjectif_atteint = false;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        if (!Isobjectif_atteint)
        {
            objectif_atteint();
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x, transform.position.y), step);
            Update_animation();

        }


    }
    IEnumerator Ranger_Stock()
    {
        animator.SetBool("Range_Stock", true);
        yield return new WaitForSeconds(2);
        
        RessourceManager.Instance.Ajouter(type);
        serviteur.GetComponentInChildren<Image>().color = new Color(0f, 0f, 0f, 0f);
        retour();
        animator.SetBool("Range_Stock", false);
    }
    public void Agir_Stock(RessourceManager.MaterialRessourceType type)
    {
        this.type = type;
        StartCoroutine("Ranger_Stock");        
    }
    public void objectif_atteint()
    {
       // Debug.Log(Isobjectif_atteint);
        if (Isobjectif_atteint == false)
        {
            float step = speed * Time.deltaTime;
            Vector2 v = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x, transform.position.y), step);
            if (transform.position.x == v.x)
            {
                target.GetComponent<Interactable>().interagir(serviteur);
                Isobjectif_atteint = true;
            }
            
        }

    }
    void Update_animation()
    {
        if (transform.position.x < target.transform.position.x)
        {
            animator.SetBool("VersGauche", false);
            animator.SetBool("VersDroite", true);
        }
        if (transform.position.x > target.transform.position.x)
        {
            animator.SetBool("VersGauche", true);
            animator.SetBool("VersDroite", false);
        }
    }
}
