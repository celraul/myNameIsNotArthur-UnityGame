﻿using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool IsJumping;
    public bool DoubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    bool IsBlowing;

    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("1");
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        // move o personagem em uma posição
        //transform.position += movement * Time.deltaTime * Speed;
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if (movement > 0)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (movement < 0)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
            anim.SetBool("walk", false);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !IsBlowing)
        {
            if (!IsJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                DoubleJump = true;

                anim.SetBool("jump", true);
            }
            else
            {
                if (DoubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce * 1.2f), ForceMode2D.Impulse);
                    DoubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            IsJumping = false;
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
            IsJumping = true;
    }

    // em constante colisão
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
            IsBlowing = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
            IsBlowing = false;
    }
}
