using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_pause : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject CanvasPause;
    public Button btnPause;
    public Button btnMenu;
    public Button btnContinue;

    void Start()
    {
        resume();
        btnPause.onClick.AddListener(updateState);
        btnMenu.onClick.AddListener(getBackMenu);
        btnContinue.onClick.AddListener(resume);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            updateState();
        }
    }

    void resume()
    {
        CanvasPause.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
        //btnPause.gameObject.setActive(true);
    }

    void pause()
    {
        CanvasPause.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
        //btnPause.GetComponent<Image>().color = new Color(0f,0f,0f,0f);
        //btnPause.gameObject.setActive(false);
    }

    void updateState()
    {
        if (gameIsPause == true)
        {
            resume();

        }
        else
        {
            pause();
        }
    }

    void getBackMenu()
    {
        SceneManager.LoadScene(0);
    }

}
