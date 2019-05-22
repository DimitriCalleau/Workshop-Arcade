﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller_1Player : MonoBehaviour
{
    //Movement et Tirs
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
    public Rigidbody2D rigidbody;

    //Vie

    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        Health = 4;
    }

    private void FixedUpdate()
    {
        //Jump
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
        //Debug.Log(rigidbody.velocity.y);
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
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }

        if (Health <= 0)
        {
            //Faire réap? mettre le score a ?juste detruire?
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Health -= 1;
    }
}
