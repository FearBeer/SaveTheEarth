using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgradesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerHPCost;
    [SerializeField] private TextMeshProUGUI earthHPCost;
    [SerializeField] private TextMeshProUGUI reloadCost;
    [SerializeField] private TextMeshProUGUI playerSpeedCost;
    [SerializeField] private TextMeshProUGUI projectileDamageCost;

    void Start()
    {
        playerHPCost.text = $"Extra Life:\n\n {DataManger.Instance.playerHealthCost}";
        earthHPCost.text = $"Earth HP:\n\n {DataManger.Instance.earthHealthCost}";
        reloadCost.text = $"Reload Time:\n\n {DataManger.Instance.reloadTimeCost}";
        playerSpeedCost.text = $"Station speed:\n\n {DataManger.Instance.playerSpeedCost}";
        projectileDamageCost.text = $"Damage:\n\n {DataManger.Instance.projectileDamageCost}";
    }
}
