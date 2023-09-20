using TMPro;
using UnityEngine;

public class ShopUpgradesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerHPCost;
    [SerializeField] private TextMeshProUGUI earthHPCost;
    [SerializeField] private TextMeshProUGUI reloadCost;
    [SerializeField] private TextMeshProUGUI playerSpeedCost;
    [SerializeField] private TextMeshProUGUI projectileDamageCost;
    [SerializeField] private TextMeshProUGUI fuelCapacityCost;

    void Start()
    {
        playerHPCost.text = $"Extra Life:\n\n {DataManger.Instance.playerHealthCost}";
        earthHPCost.text = $"Earth HP:\n\n {DataManger.Instance.earthHealthCost}";
        reloadCost.text = $"Reload Time:\n\n {DataManger.Instance.reloadTimeCost}";
        playerSpeedCost.text = $"Station speed:\n\n {DataManger.Instance.playerSpeedCost.ToString("0.0")}";
        projectileDamageCost.text = $"Damage:\n\n {DataManger.Instance.projectileDamageCost}";
        fuelCapacityCost.text = $"Fuel:\n\n {DataManger.Instance.fuelCapacityCost}";
    }
}
