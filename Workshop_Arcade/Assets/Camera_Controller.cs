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
    // Start is called before the first frame update
    void Start()
    {
        moyenneMax = 17;
        moyenneMin = -17;
    }

    // Update is called once per frame
    void Update()
    {
        moyenne = (P1.transform.position.y + P2.transform.position.y) / 2;
        if (moyenne < moyenneMax && moyenne > moyenneMin)
        {
            this.gameObject.transform.position = new Vector3(0, moyenne, -5);
        }
        else
        {
            if(P1.transform.position.y < P2.transform.position.y)
            {
                this.gameObject.transform.position = new Vector3(0, P1.transform.position.y, -5);
            }
            if (P1.transform.position.y > P2.transform.position.y)
            {
                this.gameObject.transform.position = new Vector3(0, P2.transform.position.y, -5);
            }
        }
        Debug.Log(moyenne);
    }
}
