 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadStartScene()
    {
        Debug.Log("ELO, WITAJ W GIERCE!");
        SceneManager.LoadScene("Menu");
    }

    public void LoadGameScene()
    {
        Debug.Log("JAZDA!");
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadOptionsScene()
    {
        Debug.Log("USTAWIENIA!");
        SceneManager.LoadScene("Options");
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadGameOverScene()
    {
        Debug.Log("GG WP! YOU LOST!");
        SceneManager.LoadScene("GameOver");
    }

    public void ExitGame()
    {
        Debug.Log("EXIT!");
        Application.Quit();
    }

}