using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private GameObject moreMoney;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private string product;
    [SerializeField] private AudioClip upgradeComplete;
    [SerializeField] private AudioClip upgradeFail;
    private bool isUpgardeComplete;
    private AudioSource audioSource;
    private Button button;
    public Action<int> valueChange;

    private DataManger dataManger; 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        button = GetComponent<Button>();
        dataManger = GameObject.Find("DataManager").GetComponent<DataManger>();
    }
    private void UpgradeProduct(int cost, Action<int> action)
    {
        if (DataManger.Instance.playerInfo.money >= cost)
        {
            isUpgardeComplete = true;
            DataManger.Instance.playerInfo.money -= cost;
            action?.Invoke(cost);
            dataManger.Save();
        }
        else
        {
            isUpgardeComplete = false;
            StartCoroutine(timerRoutine());
        }
        PlaySound();
    }

    public void changePlayerHealth(int cost)
    {
        int limit = 50;
        if(DataManger.Instance.playerInfo.playerHealth < limit -1)
        {
            cost = DataManger.Instance.playerInfo.playerHealthCost;
            DataManger.Instance.playerInfo.playerHealth++;
            if(DataManger.Instance.playerInfo.playerHealth <= 10)
            {
                cost += 100;
            } else if (DataManger.Instance.playerInfo.playerHealth <= 20)
            {
                cost += 1000;
            } else
            {
                cost += 5000;
            }
            DataManger.Instance.playerInfo.playerHealthCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";
        } else if(DataManger.Instance.playerInfo.playerHealth == limit - 1)
        {
            DataManger.Instance.playerInfo.playerHealth += 1;
            DataManger.Instance.playerInfo.isMaxPlayerHP = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        } else
        {
            DataManger.Instance.playerInfo.isMaxPlayerHP = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        }
    }

    public void UpgradePlayerHealth()
    {
        UpgradeProduct(DataManger.Instance.playerInfo.playerHealthCost, changePlayerHealth);
    }

    public void changeEarthHealth(int cost)
    {
        int limit = 50;
        if(DataManger.Instance.playerInfo.earthHealth < limit - 1)
        {
            cost = DataManger.Instance.playerInfo.earthHealthCost;
            DataManger.Instance.playerInfo.earthHealth++;
            if(DataManger.Instance.playerInfo.earthHealth <= 10)
            {
                cost += 150;
            } else if (DataManger.Instance.playerInfo.earthHealth <= 20)
            {
                cost += 1500;
            } else if (DataManger.Instance.playerInfo.earthHealth <= 30)
            {
                cost += 3000;
            } else
            {
                cost += 10000;
            }
            DataManger.Instance.playerInfo.earthHealthCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";
        } else if(DataManger.Instance.playerInfo.earthHealth == limit - 1)
        {
            DataManger.Instance.playerInfo.earthHealth += 1;
            DataManger.Instance.playerInfo.isMaxEartHP = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        } else
        {
            DataManger.Instance.playerInfo.isMaxEartHP = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        }
    }

    public void UpgradeEarthHealth()
    {
        UpgradeProduct(DataManger.Instance.playerInfo.earthHealthCost, changeEarthHealth);
    }

    public void changeReloadTime(int cost)
    {
        float limit = 0.1f;
        if (DataManger.Instance.playerInfo.reloadTime > limit + 0.1f)
        {
            cost = DataManger.Instance.playerInfo.reloadTimeCost;
            DataManger.Instance.playerInfo.reloadTime -= 0.1f;
            if (DataManger.Instance.playerInfo.reloadTime >= 1.5f)
            {
                cost *= 2;
            }
            else
            {
                cost += 5000;
            }
            DataManger.Instance.playerInfo.reloadTimeCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";
        }
        else if (DataManger.Instance.playerInfo.reloadTime <= limit + 0.1f)
        {
            DataManger.Instance.playerInfo.reloadTime -= 0.1f;
            DataManger.Instance.playerInfo.isMinReloadTime = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMin";
        }
        else
        {
            DataManger.Instance.playerInfo.isMinReloadTime = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMin";
        }
    }
    public void UpgradeReloadTime()
    {
        UpgradeProduct(DataManger.Instance.playerInfo.reloadTimeCost, changeReloadTime);
    }

    public void changePlayerSpeed(int cost)
    {
        int limit = 90;
        if(DataManger.Instance.playerInfo.playerSpeed < limit - 2)
        {
            cost = DataManger.Instance.playerInfo.playerSpeedCost;
            DataManger.Instance.playerInfo.playerSpeed += 2.0f;
            if(DataManger.Instance.playerInfo.playerSpeed <= 60)
            {
                cost += 250;
            } else if (DataManger.Instance.playerInfo.playerSpeed <= 70)
            {
                cost += 500;
            } else if (DataManger.Instance.playerInfo.playerSpeed <= 80)
            {
                cost += 1000;
            } else
            {
                cost += 5000;
            }
            DataManger.Instance.playerInfo.playerSpeedCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";
        } else if(DataManger.Instance.playerInfo.playerSpeed == limit - 2)
        {
            DataManger.Instance.playerInfo.playerSpeed += 2.0f;
            DataManger.Instance.playerInfo.isMaxSpeed = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        } else
        {
            DataManger.Instance.playerInfo.isMaxSpeed = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        }
    }
    public void UpgradePlayerSpeed()
    {
        UpgradeProduct(DataManger.Instance.playerInfo.playerSpeedCost, changePlayerSpeed);
    }

    public void changeProjectileDamage(int cost)
    {
        int maxDamage = 5;
        if (DataManger.Instance.playerInfo.projectileDamage < maxDamage - 1)
        {
            cost = DataManger.Instance.playerInfo.projectileDamageCost;
            DataManger.Instance.playerInfo.projectileDamage += 1;
            cost *= 4;
            DataManger.Instance.playerInfo.projectileDamageCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";
        } else if (DataManger.Instance.playerInfo.projectileDamage == maxDamage - 1)
        {
            DataManger.Instance.playerInfo.projectileDamage += 1;
            DataManger.Instance.playerInfo.isMaxDamage = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        } else
        {
            DataManger.Instance.playerInfo.isMaxDamage = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        }
    }

    public void UpgradeProjectileDamage()
    {
        UpgradeProduct(DataManger.Instance.playerInfo.projectileDamageCost, changeProjectileDamage);
    }

    public void changeFuelCapacity(int cost)
    {
        int limit = 25600;
        if(DataManger.Instance.playerInfo.fuelCapacity < limit / 2)
        {
            cost = DataManger.Instance.playerInfo.fuelCapacityCost;
            DataManger.Instance.playerInfo.fuelCapacity *= 2;
            cost *= 2;
            DataManger.Instance.playerInfo.fuelCapacityCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";        
        } else if(DataManger.Instance.playerInfo.fuelCapacity == limit / 2)
        {
            DataManger.Instance.playerInfo.fuelCapacity *= 2;
            DataManger.Instance.playerInfo.isMaxFuel = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        } else
        {
            DataManger.Instance.playerInfo.isMaxFuel = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        }
    }

    public void UpgradeFuelCapacity()
    {
        UpgradeProduct(DataManger.Instance.playerInfo.fuelCapacityCost, changeFuelCapacity);
    }

    IEnumerator timerRoutine()
    {
        moreMoney.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        moreMoney.SetActive(false);
    }

    private void PlaySound()
    {
        if (isUpgardeComplete)
        {
            audioSource.PlayOneShot(upgradeComplete, 1.0f);
        }
        else
        {
            audioSource.PlayOneShot(upgradeFail, 1.0f);
        }
    }
}
