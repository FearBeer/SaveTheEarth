using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class BuyTicketToPlanet : MonoBehaviour
{
    [SerializeField] GameObject moreMoney;
    [SerializeField] MoneyBank moneyBank;
    [SerializeField] TextMeshProUGUI flyToPlanet;
    [SerializeField] private int cost;
    [SerializeField] private int id;
    [SerializeField] private AudioClip upgradeComplete;
    [SerializeField] private AudioClip upgradeFail;

    private bool isMoneyEnough;
    private int notLevelScenCount = 3;
    private AudioSource audioSource;
    private TextMeshProUGUI money;
    private DataManger dataManger;
    void Start()
    {
        money = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        dataManger = GameObject.Find("DataManager").GetComponent<DataManger>();
        audioSource = GetComponent<AudioSource>();

        money.text = $"Money: {moneyBank.GetAllMoneyValue()}";
        flyToPlanet.text = $"Fly to planet {id - notLevelScenCount}\n\n{cost}";
    }
    public void FlyToPlanet()
    {
        if (DataManger.Instance.money >= cost)
        {
            isMoneyEnough = true;
            DataManger.Instance.money -= cost;
            money.text = $"Money: {DataManger.Instance.money}";
            dataManger.Save();
            LevelStart(id);
        }
        else
        {
            isMoneyEnough = false;
            StartCoroutine(timerRoutine());
        }
        PlaySound();
    }

    private void LevelStart(int id)
    {
        SceneManager.LoadScene(id);
    }
    IEnumerator timerRoutine()
    {
        moreMoney.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        moreMoney.SetActive(false);
    }

    private void PlaySound()
    {
        if (isMoneyEnough)
        {
            audioSource.PlayOneShot(upgradeComplete, 1.0f);
        }
        else
        {
            audioSource.PlayOneShot(upgradeFail, 1.0f);
        }
    }
}
