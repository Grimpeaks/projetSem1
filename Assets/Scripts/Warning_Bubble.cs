using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_Bubble : MonoBehaviour
{

    public SpriteRenderer myCanvas;
   // public string Canvas_name;
    public bool displayInfo=true;

    // Start is called before the first frame update
    void Start()
    {
        
        //myCanvas = GameObject.Find(Canvas_name).GetComponent<Canvas>();
        myCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        FadeCanvas();
        Debug.Log(displayInfo);
        Debug.Log("puuuuuuute");

        // apparaitre();
    }

    public void setDisplay(bool display)
    {
        displayInfo = display;
        Debug.Log("uuhhuu");
    }

    void FadeCanvas()
    {
        if (displayInfo)
        {
            myCanvas.gameObject.SetActive(true);
        }

        else
        {
            myCanvas.gameObject.SetActive(false);
        }

    }
}
