using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreP1 : MonoBehaviour
{
    private GameObject P1;
    public Text scoreJoueur1;

    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        scoreJoueur1.text = "Score P1: " + P1.GetComponent<Character_Controller_1Player>().score;
    }
}
