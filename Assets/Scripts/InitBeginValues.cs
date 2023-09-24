using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBeginValues : MonoBehaviour
{
    public static InitBeginValues Instance;

    public void InitBeginValue()
    {
        DataManger.Instance.playerInfo.playerHealth = 1;
        DataManger.Instance.playerInfo.playerHealthCost = 100;

        DataManger.Instance.playerInfo.earthHealth = 1;
        DataManger.Instance.playerInfo.earthHealthCost = 150;

        DataManger.Instance.playerInfo.reloadTime = 2;
        DataManger.Instance.playerInfo.reloadTimeCost = 200;

        DataManger.Instance.playerInfo.projectileDamage = 1;
        DataManger.Instance.playerInfo.projectileDamageCost = 1000;

        DataManger.Instance.playerInfo.playerSpeed = 50;
        DataManger.Instance.playerInfo.playerSpeedCost = 250;

        DataManger.Instance.playerInfo.fuelCapacity = 100;
        DataManger.Instance.playerInfo.fuelCapacityCost = 100;

        DataManger.Instance.playerInfo.money = 0;
        DataManger.Instance.moneyRate = 1;

        DataManger.Instance.playerInfo.isMaxDamage = false;
        DataManger.Instance.playerInfo.isMaxEartHP = false;
        DataManger.Instance.playerInfo.isMaxFuel = false;
        DataManger.Instance.playerInfo.isMaxPlayerHP = false;
        DataManger.Instance.playerInfo.isMaxSpeed = false;
        DataManger.Instance.playerInfo.isMinReloadTime = false;
    }
}
