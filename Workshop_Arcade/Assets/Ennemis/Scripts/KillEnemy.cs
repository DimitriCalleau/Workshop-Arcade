using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public FlyingEnemy enemy;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            enemy.life = false;
        }
    }
}
