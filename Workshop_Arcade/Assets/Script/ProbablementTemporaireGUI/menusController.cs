using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menusController : MonoBehaviour
{
    public GameObject panelMort;
    private GameObject P1;
    private GameObject P2;
    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.FindGameObjectsWithTag("Player")[0];
        P2 = GameObject.FindGameObjectsWithTag("Player")[1];
        panelMort.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (P1.GetComponent<Character_Controller_1Player>().score <= 0 || P2.GetComponent<Character_Controller_2Player>().score <= 0)
        {
            panelMort.SetActive(true);
            Time.timeScale = 0;
        }

    }

}
