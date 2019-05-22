using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViesP2 : MonoBehaviour
{
    private GameObject P2;
    public Text vieJoueur2;

    // Start is called before the first frame update
    void Start()
    {
        P2 = GameObject.FindGameObjectsWithTag("Player")[1];
    }

    // Update is called once per frame
    void Update()
    {
        vieJoueur2.text = "Vie P2: " + P2.GetComponent<Character_Controller_2Player>().health;
    }
}
