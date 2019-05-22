using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller_2Player : MonoBehaviour
{
    public float jumpForce;
    public int speed;
    public int amortie;

    public bool jump;
    public bool isGrounded;

    private int nbJump = 0;
    private float horizontal;
    public float ySpeed;

    private bool isShooting;
    public GameObject basicBullet;

    public GameObject shooter;
    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        
    }


    private void FixedUpdate()
    {
        //Jump
        if (nbJump >= 1)
        {
            nbJump = 0;
        }
        if (jump == true)
        {
            if (isGrounded == true)
            {
                rigidbody.AddForce(new Vector2(0f, jumpForce));
                nbJump += 1;
            }
        }

    }

    void Update()
    {
        //Debug.Log(rigidbody.velocity.y);
        //Inputs
        jump = Input.GetButtonDown("Jump2");
        horizontal = Input.GetAxis("Horizontal2");
        isShooting = Input.GetKeyDown(KeyCode.Alpha0);

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
            Debug.Log("STOPPP!");
        }

        //Tir de Base
        if(isGrounded == false)
        {
            if (isShooting == true)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, amortie);
                Instantiate(basicBullet, shooter.transform.position, shooter.transform.rotation);
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
}
