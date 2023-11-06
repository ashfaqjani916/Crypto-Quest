using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;

    public Animator playerAnim;
    public Rigidbody rb;
    public bool walking;
    public Transform playerTrans;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    //this will recieve the inputs for out Inputmanager.cs
    public void ProcessMove(Vector3 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("jog");
            playerAnim.ResetTrigger("idle");
            walking = true; 
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            
            playerAnim.ResetTrigger("idle");
            playerAnim.SetTrigger("jog");
            walking = false;
        }
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        if(isGrounded && playerVelocity.y<0)
        {
            playerVelocity.y = -2f;
        }
        
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
