using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public bool life;
    bool playerDetected;

    public float speed;

    public FlyingDetector playerDetector;

    Transform Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        life = true;
    }

    void Update()
    {
        playerDetected = playerDetector.playerDetected;

        if (playerDetected)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }

        if (!life)
        {
            Death();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (other.gameObject.GetComponent<Character_Controller_1Player>() != null)
            {
                other.gameObject.GetComponent<Character_Controller_1Player>().Degat();
            }
            else if (other.gameObject.GetComponent<Character_Controller_2Player>() != null)
            {
                other.gameObject.GetComponent<Character_Controller_2Player>().Degat();
            }
        }
    }

    void Death()
    {
        Destroy(this.gameObject, 0.1f);
    }
}
