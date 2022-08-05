using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
	{
        SceneManager.LoadScene(3);
	}
}
