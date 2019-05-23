using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panelMort;

    private GameObject P1;
    private GameObject P2;

    public Text vieJoueur1;
    public Text vieJoueur2;
    public Text scoreJoueur1;
    public Text scoreJoueur2;
    public Text mort;

    // Start is called before the first frame update
    void Start()
    {
        panelMort.SetActive(false);

        P1 = GameObject.FindGameObjectsWithTag("Player")[0];
        P2 = GameObject.FindGameObjectsWithTag("Player")[1];
    }

    // Update is called once per frame
    void Update()
    {
        scoreJoueur2.text = "Score P2: " + P2.GetComponent<Character_Controller_2Player>().score;
        vieJoueur2.text = "Vie P2: " + P2.GetComponent<Character_Controller_2Player>().health;
        vieJoueur1.text = "Vie P1: " + P1.GetComponent<Character_Controller_1Player>().health;
        scoreJoueur1.text = "Score P1: " + P1.GetComponent<Character_Controller_1Player>().score;

        if (P1.GetComponent<Character_Controller_1Player>().score <= 0 || P2.GetComponent<Character_Controller_2Player>().score <= 0)
        {
            panelMort.SetActive(true);
            Time.timeScale = 0;

            if (P1.GetComponent<Character_Controller_1Player>().score <= 0)
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
}
