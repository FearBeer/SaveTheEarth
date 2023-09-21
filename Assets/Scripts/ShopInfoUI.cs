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

    void Start()
    {
        playerLifes = GameObject.Find("Lifes").GetComponent<TextMeshProUGUI>();
        earthLifes = GameObject.Find("EarthLifes").GetComponent<TextMeshProUGUI>();
        reload = GameObject.Find("Reload").GetComponent<TextMeshProUGUI>();
        money = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        projectileDamage = GameObject.Find("ProjectileDamage").GetComponent<TextMeshProUGUI>();
        stationSpeed = GameObject.Find("StationSpeed").GetComponent<TextMeshProUGUI>();
        fuelCapacity = GameObject.Find("Fuel").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLifes.text = $"Lifes: {DataManger.Instance.playerHealth}";
        earthLifes.text = $"Earth lifes: {DataManger.Instance.earthHealth}";
        reload.text = $"Reload: {DataManger.Instance.reloadTime.ToString("0.0")}s";
        money.text = $"Money: {DataManger.Instance.money}";
        projectileDamage.text = $"Damage: {DataManger.Instance.projectileDamage}";
        stationSpeed.text = $"Speed: {DataManger.Instance.playerSpeed}";
        fuelCapacity.text = $"Fuel: {DataManger.Instance.fuelCapacity}";
    }
}