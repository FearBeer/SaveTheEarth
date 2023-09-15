using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int missionNumber;
    public int missionCost;
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
            Instance.playerHealth = 1;
            Instance.playerHealthCost = 10;
            Instance.earthHealth = 1;
            Instance.earthHealthCost = 20;
            Instance.money = 0;
            Instance.reloadTime = 2.0f;
            Instance.reloadTimeCost = 30;
            Instance.playerSpeed = 50.0f;
            Instance.playerSpeedCost = 50;
            Instance.projectileDamage = 1;
            Instance.projectileDamageCost = 500;
            Instance.missionNumber = 1;
            Instance.missionCost = 1000;
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
        public int missionNumber;
        public int missionCost;
        public int money;
    }
}
