using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Gamepad Mapping
    public string prefix;
    //

    public Animator anim;
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
        TestDeath();

        rb.AddForce(Vector3.down * gravity * mass / 2);

        //movement Manager
        if (IsGrounded())
        {
            anim.SetBool("IsFalling", false);
            if (Input.GetAxis(prefix + "Horizontal") != 0)
            {
                anim.SetBool("IsWalking", true);
                hMovement = Input.GetAxisRaw(prefix + "Horizontal") * speed;
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }
            if (Input.GetButtonDown(prefix + "Jump"))
            {
                anim.SetTrigger("Jumping");
                rb.AddForce(Vector3.right * hMovement * 2 * mass);
                rb.velocity = Vector3.up * jumpForce;
            }
            doubleJump = true;
        }
        else
        {
            anim.SetBool("IsFalling", true);
            hMovement = Input.GetAxisRaw(prefix + "Horizontal") * speed / airFriction;

            if (Input.GetButtonDown(prefix + "Jump"))
            {
                if (doubleJump == true)
                {
                    anim.SetTrigger("Jumping");
                    rb.velocity = Vector3.up * jumpForce / 1.5f;
                    doubleJump = false;
                }
            }
        }

        if (hMovement < 0)
        {
        
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * -hMovement * Time.deltaTime);
        }
        else if (hMovement > 0)
        {
            
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * hMovement * Time.deltaTime);
        }


       

        rb.AddForce(Vector3.up * airFrictionUp);
    }


    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, groundDistance + 0.1f);
    }

    void TestDeath()
    {
        if (transform.position.y < -25)
        {
            gameObject.SetActive(false);
        }
    }

}
