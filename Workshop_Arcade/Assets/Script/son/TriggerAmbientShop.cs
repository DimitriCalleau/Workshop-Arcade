﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAmbientShop : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Shop)
    {
        AkSoundEngine.PostEvent("shop_Ambient", this.gameObject);
        Debug.Log("TriggerShop");
    }
}