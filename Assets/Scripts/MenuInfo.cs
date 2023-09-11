using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuInfo : MonoBehaviour
{
    private PlayerController playerController;
   // private TextMeshProUGUI levelText;
    private TextMeshProUGUI playerLifes;
    private TextMeshProUGUI earthLifes;
    private TextMeshProUGUI reload;
    private TextMeshProUGUI money;
    private TextMeshProUGUI speed;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //levelText = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
        playerLifes = GameObject.Find("Lifes").GetComponent<TextMeshProUGUI>();
        earthLifes = GameObject.Find("EarthLifes").GetComponent<TextMeshProUGUI>();
        reload = GameObject.Find("Reload").GetComponent<TextMeshProUGUI>();
        money = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        speed = GameObject.Find("PlayerSpeed").GetComponent<TextMeshProUGUI>();        
    }

    // Update is called once per frame
    void Update()
    {
        playerLifes.text = $"Lifes: {playerController.playerHealth}";
        earthLifes.text = $"Earth lifes: {playerController.earthHealth}";
        reload.text = $"Reload: {playerController.timeToFire.ToString("0.0")}s";
        money.text = $"Money: {DataManger.Instance.money}";
        speed.text = $"Speed: {DataManger.Instance.playerSpeed}";
    }
}
