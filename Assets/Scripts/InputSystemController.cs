using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemController : MonoBehaviour
{
    public static event Action OnJump;
    public static event Action OnSlide;
    public static event Action OnDash;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || SwipeController.swipeUp)
        { 
            OnJump?.Invoke();                
        }  
        if (Input.GetKeyDown("w") || SwipeController.swipeDown) 
        {
            OnSlide?.Invoke();
        }
        if (Input.GetKeyDown("d") || SwipeController.swipeRight)
        {
            OnDash.Invoke();
        }
    }
}