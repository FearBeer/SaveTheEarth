using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowFullScreenAdvertising();

    public void ChangeScene(int index)
    {
        Fader.ChangeScene(index);
    }

    public void GameStart()
    {
        Fader.ChangeScene(4);
    }

    public void GameShop()
    {
        Fader.ChangeScene(3);
    }

    public void GameSettings()
    {
        Fader.ChangeScene(2);
    }

    public void WinScene()
    {
        Fader.ChangeScene(14);
    }
    public void TryAgain()
    {
        DataManger.Instance.playerInfo.countOfDeath++;
        if (DataManger.Instance.playerInfo.countOfDeath == 2)
        {
            ShowFullScreenAdvertising();
            DataManger.Instance.playerInfo.countOfDeath = 0;            
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    public void BackToMenu()
    {
        Fader.ChangeScene(1);
    }

}
