using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpikes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Spikes)
    {
        AkSoundEngine.PostEvent("spikes_trap", this.gameObject);
        Debug.Log("TriggerSpikes");
    }
}