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
    void Start()
    {  
        playerLifes.text = $"Lifes: {DataManger.Instance.playerHealth}";
        playerController.OnPlayerHealthChange.AddListener((health) =>
        {
            playerLifes.text = $"Lifes: {playerController.GetPlayerHealth()}";
        });

        earthLifes.text = $"Earth Lifes: {DataManger.Instance.earthHealth}";
        playerController.OnEarthHealthChange.AddListener((health) =>
        {
            earthLifes.text = $"Earth lifes: {playerController.GetEarthHealth()}";
        });

        reload.text = $"Reload: {DataManger.Instance.reloadTime.ToString("0.0")}s";
        playerController.OnTimeToFireCnahge.AddListener((time) =>
        {
            reload.text = $"Reload: {playerController.GetTimeToFire().ToString("0.0")}s";
        });

        currentMoney.text = $"Money: {DataManger.Instance.money}";
        moneyBank.OnMoneyChange.AddListener((money) =>
        {
            currentMoney.text = $"Money: {moneyBank.GetAllMoneyValue()}";
        });

        speed.text = $"Speed: {DataManger.Instance.playerSpeed}";
        damage.text = $"Damage: {DataManger.Instance.projectileDamage}";
    }
}
