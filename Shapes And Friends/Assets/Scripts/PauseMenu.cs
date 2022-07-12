using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool isActive = false;
    // Update is called once per frame
    public GameObject PauseUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
            if (!isActive)
            {
                Pause();
                
            }
            else
            {
                Resume();
                
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        PauseUI.SetActive(true);
        isActive = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseUI.SetActive(false);
        isActive = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}