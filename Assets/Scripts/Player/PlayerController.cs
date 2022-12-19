using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private CharacterController controller;
    [SerializeField] private PlayerCollision playerCollision;
    //private BoxCollider col;
    public Vector3 dir;
        
    [SerializeField] private bool isDash = false;
    [SerializeField] private bool dashLock = false;
    [SerializeField] private int health = 3;
    [SerializeField] private int maxHealth = 3;

    [SerializeField] private int speed;
    //[SerializeField] private Rigidbody rb;
    //[SerializeField] private float forwardForce = 2000f;
    [SerializeField] private float jumpForce = 650f;
    [SerializeField] private float gravity = 500f;
        
    [SerializeField] private float yLimit = -5f;
    [SerializeField] private float dashImpulse = 10f;
    [SerializeField] private int dashLockTime = 3000;
    

    [SerializeField] Text textHealth;

    private void Awake() 
    {
        InputSystemController.OnDash += InputSystemOnDash;
        InputSystemController.OnSlide += InputSystemOnSlide;
        InputSystemController.OnJump += InputSystemOnJump;
    }

    private void OnDestroy() 
    {
        InputSystemController.OnDash -= InputSystemOnDash;
        InputSystemController.OnSlide -= InputSystemOnSlide;
        InputSystemController.OnJump -= InputSystemOnJump;   
    }

    void Start()
    {
        dir.z = speed;
        //controller = GetComponent<CharacterController>();
        //col = GetComponent<BoxCollider>();
    }
    void Update()
    {
        textHealth.text = health.ToString();

        //dir.y -= gravity * Time.deltaTime;
        dir.y = Mathf.Max(dir.y - gravity * Time.deltaTime, yLimit);
        controller.Move(dir * Time.deltaTime);
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
    }

    private void Jump()
    {
        dir.y = jumpForce;
    }

    private IEnumerator Slide()
    {
        //col.center = new Vector3(0, -0.25f, 0);
        //col.size = new Vector3(1, 0.5f, 1);

        gameObject.transform.localScale = new Vector3(0.685499f, 0.6f, 0.55646f);

        yield return new WaitForSeconds(1);
            
        //col.center = new Vector3(0, 0, 0);
        //col.size = new Vector3(1f, 1f, 1f);
        gameObject.transform.localScale = new Vector3(0.685499f, 1.224929f, 0.55646f);
    }

    private void Dash()
    {
        dashLock = true;
        isDash = true;
        DashLock();
        dir.z = dashImpulse;
        NormolizeSpeed();
    }

    private async void DashLock()
    {
        await Task.Delay(dashLockTime);
        dashLock = false;
            
    }

    private async void NormolizeSpeed()
    {
        await Task.Delay(500);
        dir.z = speed;
        isDash = false;
    }
        
    private void InputSystemOnDash()
    {
        if(!dashLock)
            {
                Dash();
            }
    }
    private void InputSystemOnJump()
    {
        if(controller.isGrounded)
            {
                Jump();
                //rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
            }
    }
    private void InputSystemOnSlide()
    {
        StartCoroutine(Slide());
    }      
    public PlayerCollision GetPlayerCollision()
    {
        return playerCollision;
    }
    public int GetDamage(int damage)
    {
        return health -= damage;
    }
    public bool GetDash()
    {
        return isDash;
    }
    public bool HealPlayer(int healCount)
    {
        if(health < maxHealth)
        {
            health += healCount;
        }
        return true;
    }

}