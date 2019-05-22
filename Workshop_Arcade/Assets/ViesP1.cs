using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViesP1 : MonoBehaviour
{
    private GameObject P1;
    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        print("Vies : " + P1.GetComponent<Character_Controller_1Player>().health)
    }
}
