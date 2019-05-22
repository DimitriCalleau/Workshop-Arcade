using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientPlay : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Shop)
    {
            AkSoundEngine.PostEvent("shop_Ambient", this.gameObject);
            Debug.Log("Trigger");
    }
}

