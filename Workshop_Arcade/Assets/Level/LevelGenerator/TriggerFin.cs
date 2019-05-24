using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFin : MonoBehaviour
{
    public bool lvlFinished;
    public float delay = 1.5f;

    IEnumerator endLvl()
    {
        yield return new WaitForSeconds(delay);
        lvlFinished = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(endLvl());
        }
    }
}
