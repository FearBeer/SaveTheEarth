using UnityEngine;
using System.IO;


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
    //public int playerHealth;
    //public int playerHealthCost;
    //public int earthHealth;
    //public int earthHealthCost;
    //public float reloadTime;
    //public int reloadTimeCost;
    //public int projectileDamage;
    //public int projectileDamageCost;
    //public float playerSpeed;
    //public int playerSpeedCost;
    //public int money;
    public float moneyRate;
    //public int fuelCapacity;
    //public int fuelCapacityCost;
    
    //public bool isMaxPlayerHP;
    //public bool isMaxEartHP;
    //public bool isMinReloadTime;
    //public bool isMaxDamage;
    //public bool isMaxSpeed;
    //public bool isMaxFuel;
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
            Load();
        }
    }



    public void Save()
    {
        SaveData data = new SaveData();
        data.playerHealth = playerInfo.playerHealth;
        data.playerHealthCost = playerInfo.playerHealthCost;
        data.earthHealth = playerInfo.earthHealth;
        data.earthHealthCost = playerInfo.earthHealthCost;
        data.reloadTime = playerInfo.reloadTime;
        data.reloadTimeCost = playerInfo.reloadTimeCost;
        data.playerSpeed = playerInfo.playerSpeed;
        data.playerSpeedCost = playerInfo.playerSpeedCost;
        data.projectileDamage = playerInfo.projectileDamage;
        data.projectileDamageCost = playerInfo.projectileDamageCost;
        data.money = playerInfo.money;
        data.fuelCapacity = playerInfo.fuelCapacity;
        data.fuelCapacityCost = playerInfo.fuelCapacityCost;
        data.isMaxPlayerHP = playerInfo.isMaxPlayerHP;
        data.isMaxEartHP = playerInfo.isMaxEartHP;
        data.isMinReloadTime = playerInfo.isMinReloadTime;
        data.isMaxDamage = playerInfo.isMaxDamage;
        data.isMaxSpeed = playerInfo.isMaxSpeed;
        data.isMaxFuel = playerInfo.isMaxFuel;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerInfo.playerHealth = data.playerHealth;
            playerInfo.playerHealthCost = data.playerHealthCost;
            playerInfo.earthHealth = data.earthHealth;
            playerInfo.earthHealthCost = data.earthHealthCost;
            playerInfo.reloadTime = data.reloadTime;
            playerInfo.reloadTimeCost = data.reloadTimeCost;
            playerInfo.playerSpeed = data.playerSpeed;
            playerInfo.playerSpeedCost = data.playerSpeedCost;
            playerInfo.projectileDamage = data.projectileDamage;
            playerInfo.projectileDamageCost = data.projectileDamageCost;
            playerInfo.money = data.money;
            playerInfo.fuelCapacity = data.fuelCapacity;
            playerInfo.fuelCapacityCost = data.fuelCapacityCost;
            playerInfo.isMaxPlayerHP = data.isMaxPlayerHP;
            playerInfo.isMaxEartHP = data.isMaxEartHP;
            playerInfo.isMinReloadTime = data.isMinReloadTime;
            playerInfo.isMaxDamage = data.isMaxDamage;
            playerInfo.isMaxSpeed = data.isMaxSpeed;
            playerInfo.isMaxFuel = data.isMaxFuel;
        }
    }
}
