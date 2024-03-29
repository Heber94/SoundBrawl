﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Player player;
    float mass;
    
    
    public AudioSource pasos;
    

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
    
    private float groundDistance;

    Rigidbody rb;
    private bool doubleJump = true;

    void Start()
    { 
        player = GetComponent<Player>();
        mass = player.mass;
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
                pasos.Play();
                hMovement = Input.GetAxisRaw(prefix + "Horizontal") * speed;
            }
            else
            {
                anim.SetBool("IsWalking", false);
                pasos.Play();
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
            pasos.Stop();
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
        
        if (transform.position.y < -15)
        {
            player.Scream();
        }

        if (transform.position.y < -25)
        {
            ScoreController.AddScore(player, 1);
            gameObject.SetActive(false);
        }

        //When a player flies away, this limits the amount of distance that they stay alive
        if(transform.position.x < -100 || transform.position.x > 100)
        {
            ScoreController.AddScore(player, 1);
            gameObject.SetActive(false);
        }
    }

    void Spikes()
    {
        player.score += 1;
    }

}
