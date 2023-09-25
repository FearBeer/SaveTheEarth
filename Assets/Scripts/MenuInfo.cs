using UnityEngine;
using TMPro;

public class MenuInfo : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private MoneyBank moneyBank;
    [SerializeField] private TextMeshProUGUI playerLifes;
    [SerializeField] private TextMeshProUGUI earthLifes;
    [SerializeField] private TextMeshProUGUI reload;
    [SerializeField] private TextMeshProUGUI currentMoney;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI damage;

    private string playerHPName;
    private string earthHPName;
    private string reloadName;
    private string speedName;
    private string damageName;    
    private string moneyName;
    void Start()
    {
        if (Language.Instance.currentLanguage == "en")
        {
            playerHPName = "Shield";
            earthHPName = "Population";
            reloadName = "Reload";
            speedName = "Speed";
            damageName = "Damge";
            moneyName = "Money";
        }
        else
        {
            playerHPName = "Щит";
            earthHPName = "Население";
            reloadName = "Перезарядка";
            speedName = "Скорость";
            damageName = "Урон";
            moneyName = "Валюта";
        }
        playerLifes.text = $"{playerHPName}: {DataManger.Instance.playerInfo.playerHealth}";
        playerController.OnPlayerHealthChange.AddListener((health) =>
        {
            playerLifes.text = $"{playerHPName}: {playerController.GetPlayerHealth()}";
        });

        earthLifes.text = $"{earthHPName}: {DataManger.Instance.playerInfo.earthHealth}";
        playerController.OnEarthHealthChange.AddListener((health) =>
        {
            earthLifes.text = $"{earthHPName}: {playerController.GetEarthHealth()}";
        });

        reload.text = $"{reloadName}: {DataManger.Instance.playerInfo.reloadTime.ToString("0.0")}s";
        playerController.OnTimeToFireCnahge.AddListener((time) =>
        {
            reload.text = $"{reloadName}: {playerController.GetTimeToFire().ToString("0.0")}s";
        });

        currentMoney.text = $"{moneyName}: {DataManger.Instance.playerInfo.money}";
        moneyBank.OnMoneyChange.AddListener((money) =>
        {
            currentMoney.text = $"{moneyName}: {moneyBank.GetAllMoneyValue()}";
        });

        speed.text = $"{speedName}: {DataManger.Instance.playerInfo.playerSpeed}";
        damage.text = $"{damageName}: {DataManger.Instance.playerInfo.projectileDamage}";
    }
}
