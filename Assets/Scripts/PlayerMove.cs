using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private BoxCollider col;
    public Vector3 dir;

    [SerializeField] private int speed;
    //[SerializeField] private Rigidbody rb;
    //[SerializeField] private float forwardForce = 2000f;
    [SerializeField] private float jumpForce = 650f;
    [SerializeField] private float gravity = 500f;
    [SerializeField] private GameObject losePanel;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        col = GetComponent<BoxCollider>();
    }
    void Update()
    {
        dir.z = speed;
        dir.y -= gravity * Time.deltaTime;
        controller.Move(dir * Time.deltaTime);
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) || SwipeController.swipeUp && controller.isGrounded)
        {   
            
            Jump();
            //rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }  
        if (Input.GetKeyDown("w") || SwipeController.swipeDown) 
        {
            StartCoroutine(Slide());
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "obstacle")
        {
            losePanel.SetActive(true);
            //Time.timeScale = 0;
        }
    }
    private void Jump()
    {
        dir.y = jumpForce;
    }
    private IEnumerator Slide()
    {
        col.center = new Vector3(0, -0.25f, 0);
        col.size = new Vector3(0, 0.5f, 0);

        yield return new WaitForSeconds(1);
        
        col.center = new Vector3(0, 0, 0);
        col.size = new Vector3(1f, 1f, 1f);
        
    }

    public string CheckTrigger(string tag)
    {
        return tag;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        CheckTrigger(other.tag);
    }

}
