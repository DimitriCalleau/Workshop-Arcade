using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege : MonoBehaviour
{
    public bool pointe = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (pointe)
            {
                if (collision.gameObject.GetComponent<Character_Controller_1Player>() != null)
                {
                    collision.gameObject.GetComponent<Character_Controller_1Player>().Degat();
                }
                else if (collision.gameObject.GetComponent<Character_Controller_2Player>() != null)
                {
                    collision.gameObject.GetComponent<Character_Controller_2Player>().Degat();
                }
            }
            else
            {
                //methode pour engluer le joueur
            }
        }
    }
}
