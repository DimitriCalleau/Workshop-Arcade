using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCassables : MonoBehaviour
{
    public bool dropGem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
