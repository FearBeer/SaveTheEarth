using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    void Start()
    {

    }

    public void GameStart()
    {
        SceneManager.LoadScene(4);
    }

    public void GameShop()
    {
        SceneManager.LoadScene(3);
    }

    public void GameSettings()
    {
        SceneManager.LoadScene(2);
    }

    public void WinScene()
    {
        SceneManager.LoadScene(14);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
