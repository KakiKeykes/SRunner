using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]private Animator _animDoor1;
    [SerializeField]private Animator _animDoor2;
    // Start is called before the first frame update
    
    public void OnMouseDown()
    {
        Open();
    }

    // Update is called once per frame
    public void Open()
    {
        _animDoor1.SetBool("OpenDoor", true);
        _animDoor2.SetBool("OpenDoor", true);
    }
}
