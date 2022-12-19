using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField]private Animator _animator;
    
    public void OnMouseDown()
    {
        Open();
    }

    public void Open()
    {
        _animator.SetBool("OpenStairs", true);
    }
}
