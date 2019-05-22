using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientPlay : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collision2D Shop)
    {
        if (Shop.gameObject.name == "ShopTrigger")
        {
            AkSoundEngine.PostEvent("shop_Ambient", this.gameObject);
        }
    }
}
