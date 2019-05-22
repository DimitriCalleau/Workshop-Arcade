using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAmbientShop : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

    void OnTriggerEnter2D(Collider2D col)
    {
        p1 = GameObject.FindGameObjectsWithTag("Player")[0];

        if (col.gameObject == p1)
        {
            AkSoundEngine.PostEvent("shop_Ambient", this.gameObject);
            Debug.Log("TriggerShop");
        }

        p2 = GameObject.FindGameObjectsWithTag("Player")[1];

        if (col.gameObject == p1 || col.gameObject == p2)
        {
            AkSoundEngine.PostEvent("shop_Ambient", this.gameObject);
            Debug.Log("TriggerShop");
        }
    }
}