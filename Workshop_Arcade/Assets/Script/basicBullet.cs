using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicBullet : MonoBehaviour
{
    private GameObject P1;
    private GameObject P2;

    public int bulletSpeed;

    public Rigidbody2D rigidbody2;
    private void Start()
    {
        P1 = GameObject.FindGameObjectsWithTag("Player")[0];
        P2 = GameObject.FindGameObjectsWithTag("Player")[1];
    }
    void Update()
    {
        rigidbody2.AddForce(new Vector2(rigidbody2.velocity.x, -bulletSpeed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            AkSoundEngine.PostEvent("Enm_Die_Shot", this.gameObject);
            Debug.Log("TriggerShotEnnemi"); 
            Destroy(this.gameObject);
            if(gameObject.name == "P1 Bullet")
            {
                P1.GetComponent<Character_Controller_1Player>().score += 10;
            }
            if (gameObject.name == "P2 Bullet")
            {
                P2.GetComponent<Character_Controller_2Player>().score += 10;
            }
        }
        if (other.gameObject.tag == "Ground")
        {
            AkSoundEngine.PostEvent("block_break_shot", this.gameObject);
            Debug.Log("TriggerShotBlock");
            Destroy(this.gameObject);
        }
    }
}