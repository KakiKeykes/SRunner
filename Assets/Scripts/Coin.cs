using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private GameObject coin;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(coin);
            coinText.text = (int.Parse(coinText.text) + 1).ToString();
        }
    }



}
