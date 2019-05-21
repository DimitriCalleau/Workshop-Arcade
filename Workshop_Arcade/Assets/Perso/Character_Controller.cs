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

    public Rigidbody2D Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        jump = Input.GetButtonDown("Jump");
        horizontal = Input.GetAxis("Horizontal");
        //Jump
        if (jump == true)
        {
            if(isGrounded == true)
            {
                Rigidbody.AddForce(new Vector2(0f, jumpForce*Time.deltaTime));
                nbJump += 1;
            }               
        }
        if (nbJump >= 1)
        {
            isGrounded = false;
            nbJump = 0;
        }
        //DroiteGauche
        if(horizontal > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (horizontal < 0)
        {
            Vector3 bignou2 = new Vector2(-speed*Time.deltaTime,0);
        }
        if (horizontal != 0 && Rigidbody.velocity.magnitude <= speed)
        {
            Rigidbody.velocity = new Vector2(speed * horizontal * Time.deltaTime, Rigidbody.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
    }
}
