using UnityEngine;
using System.Runtime.InteropServices;

public class Yandex : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void RateGame();

    public void RateGameButton()
    {
        RateGame();
    }
}
