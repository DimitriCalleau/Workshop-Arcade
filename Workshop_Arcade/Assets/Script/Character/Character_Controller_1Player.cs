using System.Collections;
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
    private GameObject P2;
    public Rigidbody2D rigidbody;

    //Vie et Score
    public int score = 0;
    public int health = 4;

    //Munitions
    public int munitions = 8;
    public int munitionsMax;


    void Start()
    {
        isGrounded = false;
        P2 = GameObject.FindGameObjectsWithTag("Player")[1];
        munitionsMax = 8;
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
                if (munitions > 0)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, amortie);
                    Instantiate(basicBullet, shooter.transform.position, shooter.transform.rotation);
                    munitions -= 1;
                }
            }
        }

        if(isGrounded == true)
        {
            munitions += 1;

            if(munitions >= munitionsMax)
            {
                munitions = munitionsMax;
            }
        }
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

        //mort
        if (health <= 0)
        {
            gameObject.transform.position = P2.transform.position;
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
        if(other.gameObject.tag == "Enemy")
        {
            AkSoundEngine.PostEvent("Char_Hit", this.gameObject);
            health -= 1;
            Debug.Log("ta grosse daronee");
        }
    }
}
