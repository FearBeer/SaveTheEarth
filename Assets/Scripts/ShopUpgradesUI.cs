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

    private string playerHPName;
    private string earthHPName;
    private string reloadName;
    private string speedName;
    private string damageName;
    private string fuelName;

    void Awake()
    {
        if(Language.Instance.currentLanguage == "en")
        {
            playerHPName = "Shield +1";
            earthHPName = "Population +1";
            reloadName = "Reload -0,1";
            speedName = "Speed +2";
            damageName = "Damge +1";
            fuelName = "Fuel";
        } else
        {
            playerHPName = "Щит +1";
            earthHPName = "Население +1";
            reloadName = "Перезарядка -0,1";
            speedName = "Скорость +2";
            damageName = "Урон +1";
            fuelName = "Топливо";
        }
        if(DataManger.Instance.playerInfo.isMaxPlayerHP)
        {
            playerHPButton.interactable = false;
            playerHPCost.text = $"{playerHPName}:\n\n Max";
        } else
        {
            playerHPCost.text = $"{playerHPName}:\n\n {DataManger.Instance.playerInfo.playerHealthCost}";
        }

        if (DataManger.Instance.playerInfo.isMaxEartHP)
        {
            earthHPButton.interactable = false;
            earthHPCost.text = $"{earthHPName}:\n\n Max";
        }
        else
        {
            earthHPCost.text = $"{earthHPName}:\n\n {DataManger.Instance.playerInfo.earthHealthCost}";
        }

        if (DataManger.Instance.playerInfo.isMinReloadTime)
        {
            reloadButton.interactable = false;
            reloadCost.text = $"{reloadName}:\n\n Min";
        }
        else
        {
            reloadCost.text = $"{reloadName}:\n\n {DataManger.Instance.playerInfo.reloadTimeCost}";
        }

        if (DataManger.Instance.playerInfo.isMaxSpeed)
        {
            speedButton.interactable = false;
            playerSpeedCost.text = $"{speedName}:\n\n Max";
        }
        else
        {
            playerSpeedCost.text = $"{speedName}:\n\n {DataManger.Instance.playerInfo.playerSpeedCost}";
        }
        
        if (DataManger.Instance.playerInfo.isMaxDamage)
        {
            damageButton.interactable = false;
            projectileDamageCost.text = $"{damageName}:\n\n Max";
        }
        else
        {
            projectileDamageCost.text = $"{damageName}:\n\n {DataManger.Instance.playerInfo.projectileDamageCost}";
        }

        if (DataManger.Instance.playerInfo.isMaxFuel)
        {
            fuelButton.interactable = false;
            fuelCapacityCost.text = $"{fuelName}:\n\n Max";
        }
        else
        {
            fuelCapacityCost.text = $"{fuelName}:\n\n {DataManger.Instance.playerInfo.fuelCapacityCost}";
        }
    }
}
