using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragile : MonoBehaviour
{
    public bool dropItem;
    public GameObject gem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            if (dropItem && gem != null)
            {
                Instantiate(gem, transform.position, transform.rotation);
            }
            Destroy(gameObject, 0.01f);
        }
    }
}
