using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambiant_play : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AkSoundEngine.PostEvent("shop_Ambiant", this.gameObject);
            Debug.Log("Ambiance 1");
        }
    }
}
