using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameShop()
    {
        Debug.Log("Coming soon... gameShop");
    }

    public void GameSettings()
    {
        Debug.Log("Coming soon... gameSettings");
    }

    public void NextLevel()
    {
        int allScenceCount = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex < allScenceCount - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        } else
        {
            Debug.Log("Coming soon... NextLevel");
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
