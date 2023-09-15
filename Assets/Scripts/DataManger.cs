using System;
using System.Collections;
using System.Collections.Generic;
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
        }
    }
}
