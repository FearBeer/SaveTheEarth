using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Upgrade : MonoBehaviour
{
    [SerializeField] GameObject moreMoney;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] string product;
    [SerializeField] private AudioClip upgradeComplete;
    [SerializeField] private AudioClip upgradeFail;
    private bool isUpgardeComplete;
    private AudioSource audioSource;
    public Action<int> valueChange;

    private DataManger dataManger; 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        cost = DataManger.Instance.playerHealthCost;
        DataManger.Instance.playerHealth++;
        cost += 50;
        DataManger.Instance.playerHealthCost = cost;
        textMeshPro.text = $"{product}:\n\n{cost}";
    }

    public void UpgradePlayerHealth()
    {
        UpgradeProduct(DataManger.Instance.playerHealthCost, changePlayerHealth);
    }

    public void changeEarthHealth(int cost)
    {
        cost = DataManger.Instance.earthHealthCost;
        DataManger.Instance.earthHealth++;
        cost += 200;
        DataManger.Instance.earthHealthCost = cost;
        textMeshPro.text = $"{product}:\n\n{cost}";
    }

    public void UpgradeEarthHealth()
    {
        UpgradeProduct(DataManger.Instance.earthHealthCost, changeEarthHealth);
    }

    public void changeReloadTime(int cost)
    {
        cost = DataManger.Instance.reloadTimeCost;
        DataManger.Instance.reloadTime -= 0.1f;
        cost *= 2;
        DataManger.Instance.reloadTimeCost = cost;
        textMeshPro.text = $"{product}:\n\n{cost}";
    }
    public void UpgradeReloadTime()
    {
        UpgradeProduct(DataManger.Instance.reloadTimeCost, changeReloadTime);
    }

    public void changePlayerSpeed(int cost)
    {
        cost = DataManger.Instance.playerSpeedCost;
        DataManger.Instance.playerSpeed += 2f;
        cost += 500;
        DataManger.Instance.playerSpeedCost = cost;
        textMeshPro.text = $"{product}:\n\n{cost}";
    }
    public void UpgradePlayerSpeed()
    {
        UpgradeProduct(DataManger.Instance.playerSpeedCost, changePlayerSpeed);
    }

    public void changeProjectileDamage(int cost)
    {
        cost = DataManger.Instance.projectileDamageCost;
        DataManger.Instance.projectileDamage += 1;
        cost *= 2;
        DataManger.Instance.projectileDamageCost = cost;
        textMeshPro.text = $"{product}:\n\n{cost}";
    }

    public void UpgradeProjectileDamage()
    {
        UpgradeProduct(DataManger.Instance.projectileDamageCost, changeProjectileDamage);
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
