using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public bool life;
    public bool isGrounded;
    public bool leftWalk;
    public bool rightWalk;

    public float forceMove;
    public int direction;

    public GroundDetect left;
    public GroundDetect right;

    Rigidbody2D rigidEnemy;

    void Start()
    {
        rigidEnemy = this.GetComponent<Rigidbody2D>();
        direction = 1;

        life = true;
        isGrounded = false;
    }

    void Update()
    {
        leftWalk = left.canWalk;
        rightWalk = right.canWalk;

        if (direction == 1 && !rightWalk)
        {
            Debug.Log("Change direction to left");
            direction = -1;
        }

        if (direction == -1 && !leftWalk)
        {
            Debug.Log("Change direction to right");
            direction = 1;
        }

        rigidEnemy.velocity = new Vector2(direction * forceMove, 0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Ground"))
        {
            Debug.Log("Enemy is grounded");
            isGrounded = true;
        }
    }
}
