using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    static public int level = 0;
    [Space(10)]
    public int levelLenght = 10;
    [Space(10)]
    public Transform spawnPoint;
    public GameObject player1;
    public GameObject player2;
    [Space(10)]
    public Transform nextPart;
    public GameObject[] startingParts;
    public GameObject[] levelPartsEasy;
    public GameObject[] levelPartsMedium;
    public GameObject[] levelPartsHard;
    public GameObject[] endingParts;

    void Start()
    {
        List<int> mediumPartsPos = new List<int>();
        List<int> hardPartsPos = new List<int>();

        level++;
        for (int i = 0; i < level; i++)
        {
            mediumPartsPos.Add(Random.Range(0, levelLenght));
            Debug.Log("Medium part set to index " + mediumPartsPos[i]);
        }

        for (int i = 5; i < level; i++)
        {
            hardPartsPos.Add(Random.Range(0, levelLenght));
        }

        for (int i = 0; i <= levelLenght; i++)
        {
            if (i == 0)
            {
                int partChoice = Random.Range(0, startingParts.Length);
                nextPart = Instantiate(startingParts[partChoice], nextPart).transform;

                spawnPoint = nextPart.transform.Find("SpawnPoint").transform;

                if (player1 != null)
                {
                    Instantiate(player1, spawnPoint.position, spawnPoint.rotation);
                }
                if (player2 != null)
                {
                    Instantiate(player2, spawnPoint.position, spawnPoint.rotation);
                }

                nextPart = nextPart.transform.Find("NextPart").transform;
            }
            else if (i == levelLenght)
            {
                int partChoice = Random.Range(0, endingParts.Length-1);
                Instantiate(endingParts[partChoice], nextPart).transform.Find("NextPart");
            }
            else
            {
                bool partSet = false;
                for(int j = 0; j < mediumPartsPos.ToArray().Length; j++)
                {
                    if(mediumPartsPos[j] == i && !partSet)
                    {
                        int partChoice = Random.Range(0, levelPartsMedium.Length);
                        nextPart = Instantiate(levelPartsMedium[partChoice], nextPart).transform.Find("NextPart").transform;
                        partSet = true;
                    }
                }
                for (int j = 0; j < hardPartsPos.ToArray().Length; j++)
                {
                    if (hardPartsPos[j] == i && !partSet)
                    {
                        int partChoice = Random.Range(0, levelPartsHard.Length);
                        nextPart = Instantiate(levelPartsHard[partChoice], nextPart).transform.Find("NextPart").transform;
                        partSet = true;
                    }
                }
                if (!partSet)
                {
                    int partChoice = Random.Range(0, levelPartsEasy.Length);
                    nextPart = Instantiate(levelPartsEasy[partChoice], nextPart).transform.Find("NextPart").transform;
                    partSet = true;
                }
            }
        }
        Debug.Log("Level " + level + " généré!");
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reloading Scene!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
