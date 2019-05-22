using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    private float moyenne;
    public float moyenneMax;
    public float moyenneMin;
    private Vector3 vecteurab;
    private Vector3 vecteurMoyenne;
    private Vector3 positionP1y;
    private Vector3 positionP2y;
    public int distancCam;
    public float oui;

    // Start is called before the first frame update
    void Start()
    {
        distancCam = -5;
        moyenneMax = 17;
        moyenneMin = -17;
    }

    // Update is called once per frame
    void Update()
    {
        positionP1y = new Vector3(0, P1.transform.position.y, distancCam);
        positionP2y = new Vector3(0, P2.transform.position.y, distancCam);

        moyenne = (P1.transform.position.y + P2.transform.position.y) / 2;

        vecteurMoyenne = new Vector3(0, moyenne, distancCam);

        if (moyenne < moyenneMax && moyenne > moyenneMin)
        {
            this.gameObject.transform.position = new Vector3(0, moyenne, distancCam);
        }
        else
        {
            if(P1.transform.position.y < P2.transform.position.y)
            {
                transform.position = Vector3.Lerp(vecteurMoyenne, positionP1y, oui);
            }
            if (P1.transform.position.y > P2.transform.position.y)
            {
                transform.position = Vector3.Lerp(vecteurMoyenne, positionP2y, oui);
            }
        }
        Debug.Log(moyenne);
    }
}
