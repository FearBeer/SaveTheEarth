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
        SceneManager.LoadScene(3);
    }

    public void GameShop()
    {
        SceneManager.LoadScene(2);
    }

    public void GameSettings()
    {
        SceneManager.LoadScene(1);
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

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
