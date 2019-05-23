using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject P1;
    private GameObject P2;

    public Text vieJoueur1;
    public Text vieJoueur2;
    public Text scoreJoueur1;
    public Text scoreJoueur2;

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
