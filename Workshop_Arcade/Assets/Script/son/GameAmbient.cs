using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAmbient : MonoBehaviour
{
    public void Start()
    {
        AkSoundEngine.PostEvent("GameAmbient", this.gameObject);
    }
}