using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBreakTileShot : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D BreakTileShot)
    {
        AkSoundEngine.PostEvent("block_break_shot", this.gameObject);
        Debug.Log("TriggerShotBlock");
    }
}