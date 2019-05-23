﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller_2Player : MonoBehaviour
{
    public float jumpForce;
    public int speed;
    public int amortie;

    public bool jump;
    public bool isGrounded;

    private float horizontal;
    public float ySpeed;

    private bool isShooting;
    public GameObject basicBullet;

    public GameObject shooter;
    private GameObject P1;
    public Rigidbody2D rigidbody;

    //Vie et Score
    public int score = 0;
    public int health = 4;

    void Start()
    {
        isGrounded = false;
        P1 = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    private void FixedUpdate()
    {
        //Jump et Tire
        if (jump == true)
        {
            if (isGrounded == true)
            {
                rigidbody.AddForce(new Vector2(0f, jumpForce));
                AkSoundEngine.PostEvent("Jump", this.gameObject);
            }
            if (isGrounded == false)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, amortie);
                Instantiate(basicBullet, shooter.transform.position, shooter.transform.rotation);
            }
        }
    }

    void Update()
    {
        //Inputs
        jump = Input.GetButtonDown("Jump2");
        horizontal = Input.GetAxis("Horizontal2");

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

        //mort

        if (health <= 0)
        {
            gameObject.transform.position = P1.transform.position;
            health = 4;
            score -= 50;
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
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("ta grosse daronee");
            health -= 1;
        }
    }
}