using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinLobbyText : MonoBehaviour
{
    [SerializeField] Text text;

    void Update()
    {
        text.text = PlayerPrefs.GetInt("PlayerCoin", 0).ToString();
    }
}
