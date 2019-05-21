using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int difficulty = 0;
    [SerializeField]
    static public int level = 0;
    [Space(10)]
    public int levelLenght = 10;
    [Space(10)]
    public Transform spawnPoint;
    public GameObject player;
    [Space(10)]
    public Transform nextPart;
    public GameObject[] startingParts;
    public GameObject[] levelParts;
    public GameObject[] endingParts;

    void Start()
    {
        for (int i = 0; i < levelLenght; i++)
        {
            if (i == 0)
            {
                int partChoice = Random.Range(0, startingParts.Length);
                nextPart = Instantiate(startingParts[partChoice], nextPart).transform;

                spawnPoint = nextPart.transform.Find("SpawnPoint").transform;


                Instantiate(player, spawnPoint.position, spawnPoint.rotation);


                nextPart = nextPart.transform.Find("NextPart").transform;
            }
            else if (i == levelLenght - 1)
            {
                int partChoice = Random.Range(0, endingParts.Length);
                nextPart = Instantiate(endingParts[partChoice], nextPart).transform.Find("NextPart").transform;
            }
            else
            {
                int partChoice = Random.Range(0, levelParts.Length);
                nextPart = Instantiate(levelParts[partChoice], nextPart).transform.Find("NextPart").transform;
            }
        }
        level++;
        Debug.Log("Level " + level + " généré!");
    }

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reloading Scene!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    */
}
