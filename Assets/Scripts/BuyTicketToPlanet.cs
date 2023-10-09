using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BuyTicketToPlanet : MonoBehaviour
{
    [SerializeField] private GameObject moreMoney;
    [SerializeField] private TextMeshProUGUI flyToPlanet;
    [SerializeField] private float moneyRate;
    [SerializeField] private int cost;
    [SerializeField] private int id;

    private bool isFuelEnough;
    private int notLevelScenCount = 4;
    private TextMeshProUGUI fuel;
    private DataManger dataManger;
    private string fuelName;
    private string flyToPlanetName;

    void Start()
    {
        if (Language.Instance.currentLanguage == "en")
        {
            fuelName = "Fuel";
            flyToPlanetName = "Fly to planet";
        }
        else
        {
            fuelName = "Топливо";
            flyToPlanetName = "Полёт к планете";
        }
        fuel = GameObject.Find("Fuel").GetComponent<TextMeshProUGUI>();
        dataManger = GameObject.Find("DataManager").GetComponent<DataManger>();
        fuel.text = $"{fuelName}: {DataManger.Instance.playerInfo.fuelCapacity}";
        flyToPlanet.text = $"{flyToPlanetName} {id - notLevelScenCount}\n\n{cost}";
    }

    public void FlyToPlanet()
    {
        if (DataManger.Instance.playerInfo.fuelCapacity >= cost)
        {
            isFuelEnough = true;
            DataManger.Instance.moneyRate = moneyRate;
            dataManger.Save();
            LevelStart(id);
        }
        else
        {
            isFuelEnough = false;
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
        if (isFuelEnough)
        {
            AudioSystem.instance.PlaySound(AudioSystem.instance.buttonSounds[1], 1.0f);
        }
        else
        {
            AudioSystem.instance.PlaySound(AudioSystem.instance.buttonSounds[2], 1.0f);
        }
    }
}
