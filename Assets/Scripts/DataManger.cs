using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;

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
            DontDestroyOnLoad(gameObject);
            Instance = this;
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

    public void Load(string value)
    {
        playerInfo = JsonUtility.FromJson<SaveData>(value);
    }
}
