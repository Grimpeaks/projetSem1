using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_Bubble : MonoBehaviour
{

    public SpriteRenderer myCanvas;
    public bool displayInfo = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        FadeCanvas();
       
        
    }

    public void setDisplay(bool display)
    {
        displayInfo = display;
        
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