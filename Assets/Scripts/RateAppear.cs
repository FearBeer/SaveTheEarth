using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RateAppear : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Button button;
    void Start()
    {
        
    }

    void Update()
    {
        if (playerController.isGameActive)
        {
            button.gameObject.SetActive(true);
        }
    }
}
