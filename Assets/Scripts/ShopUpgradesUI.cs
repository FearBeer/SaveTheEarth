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
    [SerializeField] private TextMeshProUGUI fuelCapacityCost;

    [SerializeField] private Button playerHPButton;
    [SerializeField] private Button earthHPButton;
    [SerializeField] private Button reloadButton;
    [SerializeField] private Button speedButton;
    [SerializeField] private Button damageButton;
    [SerializeField] private Button fuelButton;

    void Awake()
    {
        if(DataManger.Instance.playerInfo.isMaxPlayerHP)
        {
            playerHPButton.interactable = false;
            playerHPCost.text = $"Extra Life:\n\n Max";
        } else
        {
            playerHPCost.text = $"Extra Life:\n\n {DataManger.Instance.playerInfo.playerHealthCost}";
        }

        if (DataManger.Instance.playerInfo.isMaxEartHP)
        {
            earthHPButton.interactable = false;
            earthHPCost.text = $"Earth HP:\n\n Max";
        }
        else
        {
            earthHPCost.text = $"Earth HP:\n\n {DataManger.Instance.playerInfo.earthHealthCost}";
        }

        if (DataManger.Instance.playerInfo.isMinReloadTime)
        {
            reloadButton.interactable = false;
            reloadCost.text = $"Reload Time:\n\n Min";
        }
        else
        {
            reloadCost.text = $"Reload Time:\n\n {DataManger.Instance.playerInfo.reloadTimeCost}";
        }

        if (DataManger.Instance.playerInfo.isMaxSpeed)
        {
            speedButton.interactable = false;
            playerSpeedCost.text = $"Speed:\n\n Max";
        }
        else
        {
            playerSpeedCost.text = $"Speed:\n\n {DataManger.Instance.playerInfo.playerSpeedCost}";
        }
        
        if (DataManger.Instance.playerInfo.isMaxDamage)
        {
            damageButton.interactable = false;
            projectileDamageCost.text = $"Damage:\n\n Max";
        }
        else
        {
            projectileDamageCost.text = $"Damage:\n\n {DataManger.Instance.playerInfo.projectileDamageCost}";
        }

        if (DataManger.Instance.playerInfo.isMaxFuel)
        {
            fuelButton.interactable = false;
            fuelCapacityCost.text = $"Fuel:\n\n Max";
        }
        else
        {
            fuelCapacityCost.text = $"Fuel:\n\n {DataManger.Instance.playerInfo.fuelCapacityCost}";
        }
    }
}
