using UnityEngine;
using TMPro;

public class ShopInfoUI : MonoBehaviour
{
    private TextMeshProUGUI playerLifes;
    private TextMeshProUGUI earthLifes;
    private TextMeshProUGUI reload;
    private TextMeshProUGUI money;
    private TextMeshProUGUI projectileDamage;
    private TextMeshProUGUI stationSpeed;
    private TextMeshProUGUI fuelCapacity;

    private string playerHPName;
    private string earthHPName;
    private string reloadName;
    private string speedName;
    private string damageName;
    private string fuelName;
    private string moneyName;

    void Start()
    {
        playerLifes = GameObject.Find("Lifes").GetComponent<TextMeshProUGUI>();
        earthLifes = GameObject.Find("EarthLifes").GetComponent<TextMeshProUGUI>();
        reload = GameObject.Find("Reload").GetComponent<TextMeshProUGUI>();
        money = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        projectileDamage = GameObject.Find("ProjectileDamage").GetComponent<TextMeshProUGUI>();
        stationSpeed = GameObject.Find("StationSpeed").GetComponent<TextMeshProUGUI>();
        fuelCapacity = GameObject.Find("Fuel").GetComponent<TextMeshProUGUI>();

        if (Language.Instance.currentLanguage == "en")
        {
            playerHPName = "Shield";
            earthHPName = "Population";
            reloadName = "Reload";
            speedName = "Speed";
            damageName = "Damge";
            fuelName = "Fuel";
            moneyName = "Money";
        }
        else
        {
            playerHPName = "Щит";
            earthHPName = "Население";
            reloadName = "Перезарядка";
            speedName = "Скорость";
            damageName = "Урон";
            fuelName = "Топливо";
            moneyName = "Валюта";
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerLifes.text = $"{playerHPName}: {DataManger.Instance.playerInfo.playerHealth}";
        earthLifes.text = $"{earthHPName}: {DataManger.Instance.playerInfo.earthHealth}";
        reload.text = $"{reloadName}: {DataManger.Instance.playerInfo.reloadTime.ToString("0.0")}s";
        money.text = $"{moneyName}: {DataManger.Instance.playerInfo.money}";
        projectileDamage.text = $"{damageName}: {DataManger.Instance.playerInfo.projectileDamage}";
        stationSpeed.text = $"{speedName}: {DataManger.Instance.playerInfo.playerSpeed}";
        fuelCapacity.text = $"{fuelName}: {DataManger.Instance.playerInfo.fuelCapacity}";
    }
}