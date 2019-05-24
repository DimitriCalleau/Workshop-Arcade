using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDetector : MonoBehaviour
{
    public bool playerDetected = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player") || collision.transform.tag.Equals("Bullet"))
        {
            playerDetected = true;
        }
    }
}
