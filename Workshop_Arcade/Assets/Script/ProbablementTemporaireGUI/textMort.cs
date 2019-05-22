using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textMort : MonoBehaviour
{
    private GameObject P1;
    private GameObject P2;
    public Text mort;
    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.FindGameObjectsWithTag("Player")[0];
        P2 = GameObject.FindGameObjectsWithTag("Player")[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(P1.GetComponent<Character_Controller_1Player>().score <= 0)
        {
            mort.text = "Le Joueur 1 à Perdu";
        }
        else if (P2.GetComponent<Character_Controller_2Player>().score <= 0)
        {
            mort.text = "Le Joueur 2 à Perdu";
        }
        else
        {
            mort.text = "";
        }
    }
}
