using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterText : MonoBehaviour
{
    [SerializeField] private string ru;
    [SerializeField] private string en;

    private void Start()
    {
        if(Language.Instance.currentLanguage == "ru")
        {
            GetComponent<TextMeshProUGUI>().text = ru;
        } else if(Language.Instance.currentLanguage == "en")
        {
            GetComponent<TextMeshProUGUI>().text = en;
        } else
        {
            GetComponent<TextMeshProUGUI>().text = ru;
        }
    }
}
