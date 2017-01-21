using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 20f;
    public float speed = 6f;
    public float airFriction = 2f;
    public float gravity = 9.8f;
    public float airFrictionUp = 6f;
    float hMovement = 0;
    public float mass;
    private float groundDistance;

    Rigidbody rb;
    private bool doubleJump = true;

    void Start()
    {
        groundDistance = .5f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(Vector3.down * gravity * mass/2 );
        

        //movement Manager
        if (IsGrounded())
        {
            hMovement = Input.GetAxisRaw("Horizontal") * speed;

            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.right * hMovement * 2 * mass);
                rb.velocity = Vector3.up * jumpForce;
            }
            doubleJump = true;
        }
        else
        {
            hMovement = Input.GetAxisRaw("Horizontal") * speed / airFriction;

            if (Input.GetButtonDown("Jump"))
            {
                if (doubleJump == true)
                {
                    rb.velocity = Vector3.up * jumpForce/1.5f;
                    doubleJump = false;
                }
            }  
        }
        transform.Translate(Vector3.right * hMovement * Time.deltaTime);
        rb.AddForce(Vector3.up * airFrictionUp);
    }


    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, groundDistance + 0.1f);
    }

}
