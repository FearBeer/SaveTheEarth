using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private DataManger dataManger;

    void Start()
    {
        dataManger = GameObject.Find("DataManager").GetComponent<DataManger>();
    }
    public void ResetToInitiial()
    {
        DataManger.Instance.playerHealth = 1;
        DataManger.Instance.playerHealthCost = 100;

        DataManger.Instance.earthHealth = 1;
        DataManger.Instance.earthHealthCost = 150;

        DataManger.Instance.reloadTime = 2;
        DataManger.Instance.reloadTimeCost = 200;

        DataManger.Instance.projectileDamage = 1;
        DataManger.Instance.projectileDamageCost = 1000;

        DataManger.Instance.playerSpeed = 50;
        DataManger.Instance.playerSpeedCost = 250;

        DataManger.Instance.fuelCapacity = 100;
        DataManger.Instance.fuelCapacityCost = 100;

        DataManger.Instance.money = 0;
        DataManger.Instance.moneyRate = 1;

        DataManger.Instance.isMaxDamage = false;
        DataManger.Instance.isMaxEartHP = false;
        DataManger.Instance.isMaxFuel = false;
        DataManger.Instance.isMaxPlayerHP = false;
        DataManger.Instance.isMaxSpeed = false;
        DataManger.Instance.isMinReloadTime = false;

        dataManger.Save();

        SceneManager.LoadScene(0);
    }
}
