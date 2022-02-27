using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseMenu : MonoBehaviour
{

    public GameObject ButtonPanel;
    public GameObject CreditPanel;

    public void PlayAgain()
    {
        ButtonPanel.SetActive(true);
    }
    public void Button1()
    {
        SceneManager.LoadScene(1);
    }

    public void Button2()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Credit()
    {
        CreditPanel.SetActive(true);
    }

    public void BackButton()
    {
        CreditPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
