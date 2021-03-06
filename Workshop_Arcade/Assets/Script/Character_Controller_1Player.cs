﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller_1Player : MonoBehaviour
{
    //Movement et Tirs
    public float jumpForce = 1500;
    public int speed = 15;
    public int amortie = 10;

    public bool jump;
    public bool isGrounded;

    private float horizontal;
    public float ySpeed = -200;

    private bool isShooting;
    public GameObject basicBullet;

    public GameObject shooter;
    private GameObject P2;
    public Rigidbody2D rigidbody;
    public Animator animator;

    //Vie et Score
    public float score = 0;
    public int health = 4;

    //Munitions
    public int munitions = 8;
    public int munitionsMax;

    //land sound
    public int landP1 = 0;

    //death sound
    public int non_repeatP1 = 0;

    private void Start()
    {
        munitionsMax = 8;
        isGrounded = false;
    }

    void Update()
    {
        //Inputs
        jump = Input.GetButtonDown("Jump");
        horizontal = Input.GetAxis("Horizontal");

        //DroiteGauche
        if(horizontal > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (horizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (horizontal != 0)
        {
            rigidbody.velocity = new Vector2(speed * horizontal, rigidbody.velocity.y);

        }

        //vitesse descente
        if (rigidbody.velocity.y <= ySpeed)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, ySpeed);
        }

        //Jump et Tire
        if (jump == true)
        {
            if (isGrounded == true)
            {
                rigidbody.AddForce(new Vector2(0f, jumpForce));
                AkSoundEngine.PostEvent("Jump", this.gameObject);
                jump = false;
            }
            if (isGrounded == false)
            {
                if (munitions > 0)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, amortie);
                    Instantiate(basicBullet, shooter.transform.position, shooter.transform.rotation);
                    munitions -= 1;
                    AkSoundEngine.PostEvent("Shoot", this.gameObject);
                    jump = false;
                }
            }
        }

        if (isGrounded == true)
        {
            munitions += 1;

            if (munitions >= munitionsMax)
            {
                munitions = munitionsMax;
            }
        }

        //score
        float positionInt = 0;
        positionInt += Mathf.Floor(transform.position.y);
        score =100 + Mathf.Floor(-positionInt / Time.time)*5;
        
        //mort
        if (health <= 0)
        {
            animator.SetBool("p2IsDead", true);
            AkSoundEngine.PostEvent("Char_Die", this.gameObject);
            non_repeatP1 += 1;
            if (non_repeatP1 == 1)
            {
                AkSoundEngine.PostEvent("Char_Die", this.gameObject);
            }
        }

        //son jump
        if (isGrounded == true && jump == true)
        {
            landP1 += 1;
            if (landP1 == 1)
            {
                AkSoundEngine.PostEvent("Land", this.gameObject);
                landP1 = 0;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            AkSoundEngine.PostEvent("Char_Hit", this.gameObject);
            health -= 1;
        }
    }

    public void Degat()
    {
        health -= 1;
    }
}
