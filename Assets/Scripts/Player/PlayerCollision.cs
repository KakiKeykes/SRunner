using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerCollision : MonoBehaviour
{
    public event Action<GameObject> OnInteractionCollision;
    [SerializeField] private GameObject losePanel;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        OnInteractionCollision?.Invoke(hit.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnInteractionCollision?.Invoke(other.gameObject);
    }
}