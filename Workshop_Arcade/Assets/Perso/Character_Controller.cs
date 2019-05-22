using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public float jumpForce;
    public int speed;

    public bool jump;
    public bool isGrounded;

    private int nbJump = 0;
    private float horizontal;
    public float ySpeed;

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
            isGrounded = false;
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
    // Update is called once per frame
    void Update()
    {
        Debug.Log(rigidbody.velocity.y);
        //Inputs
        jump = Input.GetButtonDown("Jump");
        horizontal = Input.GetAxis("Horizontal");

        //DroiteGauche
        if(horizontal > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (horizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (horizontal != 0)
        {
            rigidbody.velocity = new Vector2(speed * horizontal, rigidbody.velocity.y);

        }
        if (rigidbody.velocity.y <= ySpeed)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, ySpeed);
            Debug.Log("STOPPP!");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
    }
}
