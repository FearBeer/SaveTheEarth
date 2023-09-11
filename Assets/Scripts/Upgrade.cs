using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] GameObject moreMoney;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] string product;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = $"{product}:\n\n{cost}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpgradeHealth()
    {
        if (DataManger.Instance.money >= cost)
        {
            DataManger.Instance.playerHealth++;
            DataManger.Instance.money -= cost;
            cost *= 2;
            textMeshPro.text = $"{product}:\n\n{cost}";
        }
        else
        {
            StartCoroutine(timerRoutine());
        }
    }

    public void UpgradeEarthHealth()
    {
        if (DataManger.Instance.money >= cost)
        {
            DataManger.Instance.earthHealth++;
            DataManger.Instance.money -= cost;
        }
        else
        {
            StartCoroutine(timerRoutine());
        }
    }

    public void UpgradeReloadTime()
    {
        if (DataManger.Instance.money >= cost)
        {
            DataManger.Instance.reloadTime -= 0.5f;
            DataManger.Instance.money -= cost;
        }
        else
        {            
            StartCoroutine(timerRoutine());
        }
    }

    public void UpgradePlayerSpeed()
    {
        if (DataManger.Instance.money >= cost)
        {
            DataManger.Instance.playerSpeed += 2f;
            DataManger.Instance.money -= cost;
        }
        else
        {
            StartCoroutine(timerRoutine());
        }
    }

    IEnumerator timerRoutine()
    {
        moreMoney.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        moreMoney.SetActive(false);
    }
}
