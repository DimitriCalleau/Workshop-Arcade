using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGlue : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Glue)
    {
        AkSoundEngine.PostEvent("glue_trap", this.gameObject);
        Debug.Log("TriggerGlue");
    }
}