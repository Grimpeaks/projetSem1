using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class InterfaceUI : MonoBehaviour
{
    public Canvas myCanvas;
    public string myString;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;


    // Start is called before the first frame update
    void Start()
    {
        //myCanvas = GameObject.Find("CanvasMenu_Bois").GetComponent<Canvas>();
        //myText = GameObject.Find("TextCanvas").GetComponent<Text>();
        myText.color = Color.clear;
        Cursor.visible = true;

    }

    // Update is called once per frame
    void Update()
    {
        FadeText();
        FadeCanvas();
    }

    private void OnMouseOver()
    {
        displayInfo = true;
    }

    private void OnMouseExit()
    {
        displayInfo = false;

    }

    void FadeText()
    {
        if(displayInfo)
        {
            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
        }

        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }
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
