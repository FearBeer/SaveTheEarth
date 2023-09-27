using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public int playerHealth;
    public int playerHealthCost;
    public int earthHealth;
    public int earthHealthCost;
    public float reloadTime;
    public int reloadTimeCost;
    public float playerSpeed;
    public int playerSpeedCost;
    public int projectileDamage;
    public int projectileDamageCost;
    public int money;
    public int fuelCapacity;
    public int fuelCapacityCost;

    public bool isMaxPlayerHP;
    public bool isMaxEartHP;
    public bool isMinReloadTime;
    public bool isMaxDamage;
    public bool isMaxSpeed;
    public bool isMaxFuel;

    public int countOfDeath;
}

public class DataManger : MonoBehaviour
{
    public SaveData playerInfo;
    public static DataManger Instance;
    public float moneyRate;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        } else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadExternal();
        }
    }

    [DllImport("__Internal")]
    private static extern void SaveExternal(string data);

    [DllImport("__Internal")]
    private static extern void LoadExternal();

    public void Save()
    {
        string json = JsonUtility.ToJson(playerInfo);
        SaveExternal(json);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioSystem.instance.PauseMusic();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioSystem.instance.PlayMusic();
    }

    public void GiveReward()
    {
        playerInfo.money += 250;
        Save();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Load(string value)
    {        
        if(value == "{}")
        {
            Save();
        } else
        {
            playerInfo = JsonUtility.FromJson<SaveData>(value);
        }
    }
}
