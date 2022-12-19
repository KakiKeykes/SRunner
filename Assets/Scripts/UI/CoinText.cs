using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public static int coin;
    [SerializeField] Text text;

    void Update()
    {
        text.text = coin.ToString();
    }
}
