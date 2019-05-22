﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicBullet : MonoBehaviour
{
    private int dmg;
    private string name;

    public int bulletSpeed;

    public Rigidbody2D rigidbody2;
    // Start is called before the first frame update
    void Start()
    {
        name = "basicBullet";
        dmg = 35;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2.AddForce(new Vector2(rigidbody2.velocity.x, -bulletSpeed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag != "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
