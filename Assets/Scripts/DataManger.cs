using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{
    public static DataManger Instance;
    public int palyerHealth;
    public int earthHealth;
    public int score;

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
        }
    }

    [Serializable] class SaveData
    {
        public int palyerHealth;
        public int earthHealth;
        public int score;
    }
}
