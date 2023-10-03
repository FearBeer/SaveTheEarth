using UnityEngine;
using UnityEngine.UI;

public class RateAppear : MonoBehaviour
{
    [SerializeField] Button button;
    void Update()
    {
        if (DataManger.Instance.playerInfo.isGameActive)
        {
            button.gameObject.SetActive(true);
        }
    }
}
