using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBreakTileRuby : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D BreakTileRuby)
    {
        AkSoundEngine.PostEvent("block_break_ruby", this.gameObject);
        Debug.Log("TriggerRubyTile");
    }
}