using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetect : MonoBehaviour
{
    public bool canWalk;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Ground"))
        {
            canWalk = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Ground"))
        {
            canWalk = true;
        }
    }
}
