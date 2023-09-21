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
        if (DataManger.Instance.money >= cost)
        {
            isUpgardeComplete = true;
            DataManger.Instance.money -= cost;
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
        if(DataManger.Instance.playerHealth < limit -1)
        {
            cost = DataManger.Instance.playerHealthCost;
            DataManger.Instance.playerHealth++;
            if(DataManger.Instance.playerHealth <= 10)
            {
                cost += 100;
            } else if (DataManger.Instance.playerHealth <= 20)
            {
                cost += 1000;
            } else
            {
                cost += 5000;
            }
            DataManger.Instance.playerHealthCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";
        } else if(DataManger.Instance.playerHealth == limit - 1)
        {
            DataManger.Instance.playerHealth += 1;
            DataManger.Instance.isMaxPlayerHP = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        } else
        {
            DataManger.Instance.isMaxPlayerHP = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        }
    }

    public void UpgradePlayerHealth()
    {
        UpgradeProduct(DataManger.Instance.playerHealthCost, changePlayerHealth);
    }

    public void changeEarthHealth(int cost)
    {
        int limit = 50;
        if(DataManger.Instance.earthHealth < limit - 1)
        {
            cost = DataManger.Instance.earthHealthCost;
            DataManger.Instance.earthHealth++;
            if(DataManger.Instance.earthHealth <= 10)
            {
                cost += 150;
            } else if (DataManger.Instance.earthHealth <= 20)
            {
                cost += 1500;
            } else if (DataManger.Instance.earthHealth <= 30)
            {
                cost += 3000;
            } else
            {
                cost += 10000;
            }
            DataManger.Instance.earthHealthCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";
        } else if(DataManger.Instance.earthHealth == limit - 1)
        {
            DataManger.Instance.earthHealth += 1;
            DataManger.Instance.isMaxEartHP = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        } else
        {
            DataManger.Instance.isMaxEartHP = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        }
    }

    public void UpgradeEarthHealth()
    {
        UpgradeProduct(DataManger.Instance.earthHealthCost, changeEarthHealth);
    }

    public void changeReloadTime(int cost)
    {
        float limit = 0.1f;
        if (DataManger.Instance.reloadTime > limit + 0.1f)
        {
            cost = DataManger.Instance.reloadTimeCost;
            DataManger.Instance.reloadTime -= 0.1f;
            if (DataManger.Instance.reloadTime >= 1.5f)
            {
                cost *= 2;
            }
            else
            {
                cost += 5000;
            }
            DataManger.Instance.reloadTimeCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";
        }
        else if (DataManger.Instance.reloadTime <= limit + 0.1f)
        {
            DataManger.Instance.reloadTime -= 0.1f;
            DataManger.Instance.isMinReloadTime = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMin";
        }
        else
        {
            DataManger.Instance.isMinReloadTime = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMin";
        }
    }
    public void UpgradeReloadTime()
    {
        UpgradeProduct(DataManger.Instance.reloadTimeCost, changeReloadTime);
    }

    public void changePlayerSpeed(int cost)
    {
        int limit = 90;
        if(DataManger.Instance.playerSpeed < limit - 2)
        {
            cost = DataManger.Instance.playerSpeedCost;
            DataManger.Instance.playerSpeed += 2.0f;
            if(DataManger.Instance.playerSpeed <= 60)
            {
                cost += 250;
            } else if (DataManger.Instance.playerSpeed <= 70)
            {
                cost += 500;
            } else if (DataManger.Instance.playerSpeed <= 80)
            {
                cost += 1000;
            } else
            {
                cost += 5000;
            }
            DataManger.Instance.playerSpeedCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";
        } else if(DataManger.Instance.playerSpeed == limit - 2)
        {
            DataManger.Instance.playerSpeed += 2.0f;
            DataManger.Instance.isMaxSpeed = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        } else
        {
            DataManger.Instance.isMaxSpeed = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        }
    }
    public void UpgradePlayerSpeed()
    {
        UpgradeProduct(DataManger.Instance.playerSpeedCost, changePlayerSpeed);
    }

    public void changeProjectileDamage(int cost)
    {
        int maxDamage = 5;
        if (DataManger.Instance.projectileDamage < maxDamage - 1)
        {
            cost = DataManger.Instance.projectileDamageCost;
            DataManger.Instance.projectileDamage += 1;
            cost *= 4;
            DataManger.Instance.projectileDamageCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";
        } else if (DataManger.Instance.projectileDamage == maxDamage - 1)
        {
            DataManger.Instance.projectileDamage += 1;
            DataManger.Instance.isMaxDamage = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        } else
        {
            DataManger.Instance.isMaxDamage = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        }
    }

    public void UpgradeProjectileDamage()
    {
        UpgradeProduct(DataManger.Instance.projectileDamageCost, changeProjectileDamage);
    }

    public void changeFuelCapacity(int cost)
    {
        int limit = 25600;
        if(DataManger.Instance.fuelCapacity < limit / 2)
        {
            cost = DataManger.Instance.fuelCapacityCost;
            DataManger.Instance.fuelCapacity *= 2;
            cost *= 2;
            DataManger.Instance.fuelCapacityCost = cost;
            textMeshPro.text = $"{product}:\n\n{cost}";        
        } else if(DataManger.Instance.fuelCapacity == limit / 2)
        {
            DataManger.Instance.fuelCapacity *= 2;
            DataManger.Instance.isMaxFuel = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        } else
        {
            DataManger.Instance.isMaxFuel = true;
            button.interactable = false;
            textMeshPro.text = $"{product}:\n\nMax";
        }
    }

    public void UpgradeFuelCapacity()
    {
        UpgradeProduct(DataManger.Instance.fuelCapacityCost, changeFuelCapacity);
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
