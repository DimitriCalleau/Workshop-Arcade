using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientShop : MonoBehaviour
{
    public void Start()
    {
        AkSoundEngine.PostEvent("shop_Ambient", this.gameObject);
    }
}