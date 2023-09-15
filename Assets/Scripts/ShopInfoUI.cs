using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopInfoUI : MonoBehaviour
{
    private TextMeshProUGUI playerLifes;
    private TextMeshProUGUI earthLifes;
    private TextMeshProUGUI reload;
    private TextMeshProUGUI money;
    private TextMeshProUGUI projectileDamage;
    // Start is called before the first frame update
    void Start()
    {
        playerLifes = GameObject.Find("Lifes").GetComponent<TextMeshProUGUI>();
        earthLifes = GameObject.Find("EarthLifes").GetComponent<TextMeshProUGUI>();
        reload = GameObject.Find("Reload").GetComponent<TextMeshProUGUI>();
        money = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        projectileDamage = GameObject.Find("ProjectileDamage").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLifes.text = $"Lifes: {DataManger.Instance.playerHealth}";
        earthLifes.text = $"Earth lifes: {DataManger.Instance.earthHealth}";
        reload.text = $"Reload: {DataManger.Instance.reloadTime}s";
        money.text = $"Money: {DataManger.Instance.money}";
        projectileDamage.text = $"Damage: {DataManger.Instance.projectileDamage}";
    }
}