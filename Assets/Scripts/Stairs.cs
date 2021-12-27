using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    //private bool _openStairs;
    [SerializeField]private Animator _animator;
    // Start is called before the first frame update
    
    public void OnMouseDown()
    {
        Debug.Log("1");
        Open();
    }

    // Update is called once per frame
    public void Open()
    {
        Debug.Log("2");
        _animator.SetBool("OpenStairs", true);
    }
}
