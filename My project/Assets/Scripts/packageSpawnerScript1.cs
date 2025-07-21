using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class packageSpawnerScript1 : MonoBehaviour
{
    public List<GameObject> packageList = new List<GameObject>();
    public int countPerPackage = 5;

    private List<GameObject> spawnQueue = new List<GameObject>();
    private int spawnIndex = 0;

    // Can change spawnRate from editor
    private float timer = 0;
    // To control spawn rates
    public float initialSpawnRate;
    public float currentSpawnRate;
    public float difficulty; //Changes how fast the spawnrate changes
    private float levelTimer = 0f;
    public bool gamePlay = true;

    public GameObject endGamePanel;
    public ScoreManager scoreManager;
    private bool gameOverTriggered = false; // Flag to ensure GameOver() is called only once
    public TextMeshProUGUI finalScoreText; 
    public packageSpawnerScript1 spawnScript;
  
    private bool allPackagesDelivered = false;


    // Start is called before the first frame update
    void Start()
    {
        // Resets current spawn rate
        currentSpawnRate = initialSpawnRate;

          foreach (GameObject pkg in packageList)
        {
            for (int i = 0; i < countPerPackage; i++)
            {
                spawnQueue.Add(pkg);
            }
        }

        // Shuffle the list
        for (int i = 0; i < spawnQueue.Count; i++)
        {
            GameObject temp = spawnQueue[i];
            int randIndex = UnityEngine.Random.Range(i, spawnQueue.Count);
            spawnQueue[i] = spawnQueue[randIndex];
            spawnQueue[randIndex] = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePlay && !gameOverTriggered)
        {
            // Increases spawn rate over time
            levelTimer += Time.deltaTime;
            currentSpawnRate = initialSpawnRate - (difficulty * levelTimer);
            // Slows the time between spawns to spawnRate value in seconds
            if (timer < currentSpawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                if (spawnIndex < spawnQueue.Count)
                {
                    Instantiate(spawnQueue[spawnIndex], transform.position, transform.rotation);
                    spawnIndex++;
                }
                else
                {
                    Debug.Log("All packages have been spawned.");
                    // When all the packages have been spawned, trigger GameOver

                }
                timer = 0;


                    if (scoreManager.GetScore() == 3) //bit to change to find final score, before endgamepanel is set.
                    {
                        allPackagesDelivered = true;
                    }


                if (allPackagesDelivered == true)
                {
                    gamePlay = false;
                    GameOver();
                }
                
            }
        }
    }
    
       void GameOver()
    {
        gameOverTriggered = true; // Ensure this only runs once
        endGamePanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
        Debug.Log("Game over");

        // Get the final score from ScoreManager
        int finalScore = scoreManager.GetScore();
        finalScoreText.text = "" + finalScore;

        // Reset package spawn rate
        spawnScript.resetSpawnRate();

        //Saves score to highscore table
        GameObject.FindWithTag("GameController").GetComponent<ScoreManager>().SubmitScore("Level1");
    }
    public void resetSpawnRate()
    {
        levelTimer = 0f;
        currentSpawnRate = initialSpawnRate;

    }
   
}
