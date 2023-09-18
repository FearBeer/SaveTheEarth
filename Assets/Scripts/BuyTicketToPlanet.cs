using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BuyTicketToPlanet : MonoBehaviour
{
    [SerializeField] private GameObject moreMoney;
    [SerializeField] private MoneyBank moneyBank;
    [SerializeField] private TextMeshProUGUI flyToPlanet;
    [SerializeField] private AudioClip upgradeComplete;
    [SerializeField] private AudioClip upgradeFail;
    [SerializeField] private float moneyRate;
    [SerializeField] private int cost;
    [SerializeField] private int id;

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
            DataManger.Instance.moneyRate = moneyRate;
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
