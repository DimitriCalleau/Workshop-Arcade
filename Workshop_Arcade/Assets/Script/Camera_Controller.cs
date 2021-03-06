﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    private GameObject P1;
    private GameObject P2;
    private float moyenne;
    public float hauteurMax = 10;
    public float hauteurMin = -10;
    private Vector3 vecteurab;
    private Vector3 vecteurMoyenne;
    private Vector3 positionP1y;
    private Vector3 positionP2y;
    public int distanceCam = -20;
    private float trucpourlelerpjsaispascequecest = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.FindGameObjectsWithTag("Player")[0];
        P2 = GameObject.FindGameObjectsWithTag("Player")[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(P2 != null)
        {
            positionP1y = new Vector3(0, P1.transform.position.y, distanceCam);
            positionP2y = new Vector3(0, P2.transform.position.y, distanceCam);

            moyenne = (P1.transform.position.y + P2.transform.position.y) / 2;
            vecteurMoyenne = new Vector3(0, moyenne, distanceCam);


            if (P1.transform.position.y < moyenne + hauteurMax && P1.transform.position.y > moyenne + hauteurMin)
            {

                if (P2.transform.position.y < moyenne + hauteurMax && P2.transform.position.y > moyenne + hauteurMin)
                {
                    gameObject.transform.position = new Vector3(0, moyenne, distanceCam);
                }
            }
            else
            {
                if (P2.transform.position.y < P1.transform.position.y)
                {
                    transform.position = Vector3.Lerp(vecteurMoyenne, positionP2y, trucpourlelerpjsaispascequecest);
                    P1.GetComponent<Character_Controller_1Player>().score -= 10;
                    P1.transform.position = P2.transform.position;
                }
                if (P2.transform.position.y > P1.transform.position.y)
                {
                    transform.position = Vector3.Lerp(vecteurMoyenne, positionP1y, trucpourlelerpjsaispascequecest);
                    P2.GetComponent<Character_Controller_2Player>().score -= 10;
                    P2.transform.position = P1.transform.position;
                }
            }
        }
        else
        {
            gameObject.transform.position = new Vector3(0, P1.transform.position.y, distanceCam);
        }

    }
}
