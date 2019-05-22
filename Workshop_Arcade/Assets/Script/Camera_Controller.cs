using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    private GameObject P1;
    private GameObject P2;
    private float moyenne = -5;
    public float hauteurMax = 17;
    public float hauteurMin = -17;
    private Vector3 vecteurab;
    private Vector3 vecteurMoyenne;
    private Vector3 positionP1y;
    private Vector3 positionP2y;
    public int distancCam;
    public float trucpourlelerpjsaispascequecest;

    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.FindGameObjectsWithTag("Player")[0];
        P2 = GameObject.FindGameObjectsWithTag("Player")[1];
    }

    // Update is called once per frame
    void Update()
    {
        positionP1y = new Vector3(0, P1.transform.position.y, distancCam);
        positionP2y = new Vector3(0, P2.transform.position.y, distancCam);

        moyenne = (P1.transform.position.y + P2.transform.position.y) / 2;

        vecteurMoyenne = new Vector3(0, moyenne, distancCam);

        if (moyenne < hauteurMax && moyenne > hauteurMin)
        {
            this.gameObject.transform.position = new Vector3(0, moyenne, distancCam);
        }
        else
        {
            if(P1.transform.position.y < P2.transform.position.y)
            {
                transform.position = Vector3.Lerp(vecteurMoyenne, positionP1y, trucpourlelerpjsaispascequecest);
                P2.GetComponent<Character_Controller_2Player>().score -= 50;
            }
            if (P1.transform.position.y > P2.transform.position.y)
            {
                transform.position = Vector3.Lerp(vecteurMoyenne, positionP2y, trucpourlelerpjsaispascequecest);
                P1.GetComponent<Character_Controller_1Player>().score -= 50;
            }
        }
    }
}
