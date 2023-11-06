using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody rb;
    public float ws, wbs, owls, rns, ros;
    public bool walking;
    public Transform playerTrans;

    /*private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = transform.forward * ws* Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = Vector3.zero;
        }
        if(Input.GetKey(KeyCode.S))
        { rb.velocity = -transform.forward *ws* Time.deltaTime;}
    }*/
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = transform.forward * ws * Time.deltaTime;
            playerAnim.SetTrigger("jog");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = Vector3.zero;
            playerAnim.ResetTrigger("jog");
            playerAnim.SetTrigger("idle");
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = -transform.forward * ws * Time.deltaTime;
            playerAnim.SetTrigger("jogback");
            playerAnim.ResetTrigger("idle");
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = Vector3.zero;
            playerAnim.ResetTrigger("jogback");
            playerAnim.SetTrigger("idle");
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ros * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ros * Time.deltaTime, 0);
        }

        if( walking == true)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                ws = ws + rns;
                playerAnim.SetTrigger("sprint");
                playerAnim.ResetTrigger("jog");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                ws = ws + rns;
                playerAnim.ResetTrigger("sprint");
                playerAnim.SetTrigger("jog");
            }
        }
    }
}
