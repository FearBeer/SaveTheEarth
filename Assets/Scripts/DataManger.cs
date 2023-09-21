using System;
using UnityEngine;
using System.IO;

public class DataManger : MonoBehaviour
{
    public static DataManger Instance;
    public int playerHealth;
    public int playerHealthCost;
    public int earthHealth;
    public int earthHealthCost;
    public float reloadTime;
    public int reloadTimeCost;
    public int projectileDamage;
    public int projectileDamageCost;
    public float playerSpeed;
    public int playerSpeedCost;
    public int money;
    public float moneyRate;
    public int fuelCapacity;
    public int fuelCapacityCost;
    
    public bool isMaxPlayerHP;
    public bool isMaxEartHP;
    public bool isMinReloadTime;
    public bool isMaxDamage;
    public bool isMaxSpeed;
    public bool isMaxFuel;
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

    [Serializable] class SaveData
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

    public void Save()
    {
        SaveData data = new SaveData();
        data.playerHealth = playerHealth;
        data.playerHealthCost = playerHealthCost;
        data.earthHealth = earthHealth;
        data.earthHealthCost = earthHealthCost;
        data.reloadTime = reloadTime;
        data.reloadTimeCost = reloadTimeCost;
        data.playerSpeed = playerSpeed;
        data.playerSpeedCost = playerSpeedCost;
        data.projectileDamage = projectileDamage;
        data.projectileDamageCost = projectileDamageCost;
        data.money = money;
        data.fuelCapacity = fuelCapacity;
        data.fuelCapacityCost = fuelCapacityCost;
        data.isMaxPlayerHP = isMaxPlayerHP;
        data.isMaxEartHP = isMaxEartHP;
        data.isMinReloadTime = isMinReloadTime;
        data.isMaxDamage = isMaxDamage;
        data.isMaxSpeed = isMaxSpeed;
        data.isMaxFuel = isMaxFuel;

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

            playerHealth = data.playerHealth;
            playerHealthCost = data.playerHealthCost;
            earthHealth = data.earthHealth;
            earthHealthCost = data.earthHealthCost;
            reloadTime = data.reloadTime;
            reloadTimeCost = data.reloadTimeCost;
            playerSpeed = data.playerSpeed;
            playerSpeedCost = data.playerSpeedCost;
            projectileDamage = data.projectileDamage;
            projectileDamageCost = data.projectileDamageCost;
            money = data.money;
            fuelCapacity = data.fuelCapacity;
            fuelCapacityCost = data.fuelCapacityCost;
            isMaxPlayerHP = data.isMaxPlayerHP;
            isMaxEartHP = data.isMaxEartHP;
            isMinReloadTime = data.isMinReloadTime;
            isMaxDamage = data.isMaxDamage;
            isMaxSpeed = data.isMaxSpeed;
            isMaxFuel = data.isMaxFuel;
        }
    }
}
