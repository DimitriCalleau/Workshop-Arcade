using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreP2 : MonoBehaviour
{
    private GameObject P2;
    public Text scoreJoueur2;

    // Start is called before the first frame update
    void Start()
    {
        P2 = GameObject.FindGameObjectsWithTag("Player")[1];
    }

    // Update is called once per frame
    void Update()
    {
        scoreJoueur2.text = "Score P2: " + P2.GetComponent<Character_Controller_2Player>().score;
    }
}
