using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBreakTileRuby : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D BreakTileRuby)
    {
        AkSoundEngine.PostEvent("spikes_trap", this.gameObject);
        Debug.Log("TriggerRubyTile");
    }
}