using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{
    public static DataManger Instance;
    public int playerHealth;
    public int earthHealth;
    public float reloadTime;
    public float playerSpeed;
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
            Instance.earthHealth = 1;
            Instance.money = 0;
            Instance.reloadTime = 2.0f;
            Instance.playerSpeed = 50.0f;
        }
    }

    [Serializable] class SaveData
    {
        public int playerHealth;
        public int earthHealth;
        public float reloadTime;
        public float playerSpeed;
        public int money;
    }
}
