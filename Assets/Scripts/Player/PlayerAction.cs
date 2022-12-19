using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace Player
    {
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject inGameUI;
        private PlayerCollision playerCollision;

        private void Awake()
        {
            playerCollision = playerController.GetPlayerCollision();
            playerCollision.OnInteractionCollision += PlayerOnInteractionCollision;
        }

        private void OnDestroy() 
        {
            playerCollision.OnInteractionCollision -= PlayerOnInteractionCollision;        
        }

        private void PlayerOnInteractionCollision(GameObject _gameObject)
        {
            if(_gameObject.tag == "obstacle")
            {
                if(playerController.GetDamage(1) >= 1)
                {
                    Destroy(_gameObject);
                }
                else
                {
                    playerController.dir.z = 0;
                    Destroy(_gameObject);
                    EndGame(true);
                }
                //Time.timeScale = 0;
            }
            else if(_gameObject.tag == "doorDestroy")
            {
                if(playerController.GetDash())
                {
                    Destroy(_gameObject);
                }
                else if(playerController.GetDamage(1) > 1)
                {
                    Destroy(_gameObject);
                }
                else
                {
                    playerController.dir.z = 0;
                    Destroy(_gameObject);
                    EndGame(true);
                }
            }
            else if(_gameObject.tag == "healPotion")
            {
                if(playerController.HealPlayer(1))
                {
                    Destroy(_gameObject);
                }
            }
        }

        private void EndGame(bool isDead)
        {
            int _coin;
            _coin = PlayerPrefs.GetInt("PlayerCoin", 0) + CoinText.coin;
            if (isDead)
            {
                inGameUI.SetActive(false);
                losePanel.SetActive(true);
            }
            PlayerPrefs.SetInt("PlayerCoin", _coin);
        }
    }
}