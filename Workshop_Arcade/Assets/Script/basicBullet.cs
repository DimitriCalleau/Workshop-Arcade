using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicBullet : MonoBehaviour
{

    public int bulletSpeed;

    public Rigidbody2D rigidbody2;

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
        }
        if (other.gameObject.tag == "Ground")
        {
            AkSoundEngine.PostEvent("block_break_shot", this.gameObject);
            Debug.Log("TriggerShotBlock");
            Destroy(this.gameObject);
        }
    }
}