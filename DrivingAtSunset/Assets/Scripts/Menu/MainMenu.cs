using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// This script handles the loading the scenes.
    /// </summary>

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

 

    public void QuitGame()
    {
        Application.Quit();
    }
}

