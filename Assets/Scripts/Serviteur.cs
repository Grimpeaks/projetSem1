using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Serviteur : MonoBehaviour
{
    float speed = 2;
    public GameObject target;
    Animator animator;
    public GameObject serviteur;
    public GameObject origin;
    public GameObject target_intermediaire;
    public RessourceManager.MaterialRessourceType type;
    bool Isobjectif_atteint = false;
    
    public Serviteur()
    {
    }

    public void init(GameObject t,GameObject origin,GameObject serviteur, GameObject tI=null)
    {
        target = t;
        this.serviteur = serviteur;
        this.origin = origin;
        target_intermediaire = tI;
        
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

    void Update()
    {
        if (!Isobjectif_atteint)
        {
            
            Transform the_target_transform = null;
            if (target_intermediaire == null) { the_target_transform = target.transform; }
            else if (target_intermediaire != null) { the_target_transform = target_intermediaire.transform; }
            objectif_atteint(the_target_transform);
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(the_target_transform.transform.position.x, transform.position.y), step);
            Update_animation();

        }


    }
    public void objectif_atteint(Transform the_target_transform)
    {      
        if (!Isobjectif_atteint)
        {
            float step = speed * Time.deltaTime;
    
            if (transform.position.x == the_target_transform.position.x)
            {
                
                if (target_intermediaire == null)
                {
                    target.GetComponent<Interactable>().interagir(serviteur);
                    Isobjectif_atteint = true; 
                }
                else if (target_intermediaire != null)
                {
                    target_intermediaire.GetComponent<Interactable>().interagir(serviteur);
                    target_intermediaire = null;
                    Isobjectif_atteint = true;
                }
                
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

    public void agir_Porte()
    {
        StartCoroutine("ouvrirPorte");
    }

    IEnumerator ouvrirPorte()
    {
        StartCoroutine("disparaitre");
        yield return new WaitForSeconds(2f);
        
    }

    IEnumerator disparaitre()
    {
        animator.SetBool("Disparaitre", true);
        for (int i = 0; i <= 10; i++)
        {
            Color color = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, color.a - 0.1f);
            yield return new WaitForSeconds(0.1f);

        }
        animator.SetBool("Disparaitre", false);

    }

    IEnumerator aparaitre()
    {
        animator.SetBool("Apparaitre", true);
        for (int i = 0; i <= 10; i++)
        {
            Color color = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, color.a + 0.1f);
            yield return new WaitForSeconds(0.1f);

        }
        animator.SetBool("Apparaitre", false);


    }

    IEnumerator teleporte(Transform destination)
    {
        transform.position = destination.transform.position;
        StartCoroutine("aparaitre");
        yield return new WaitForSeconds(1f);
        Isobjectif_atteint = false;

    }

    public void teleporter(GameObject destination) {
        //transform.position = destination.transform.position;
        StartCoroutine("teleporte",destination.transform);
        

    }
}
