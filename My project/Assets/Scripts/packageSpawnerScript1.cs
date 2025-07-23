/*using System;
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
        public PackageManager deliverManager;
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
        
private int totalPackagesDelivered = 0;

public void NotifyPackageDelivered()
{
    totalPackagesDelivered++;
    Debug.Log("Total packages delivered: " + totalPackagesDelivered);
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
                      //  Debug.Log("All packages have been spawned.");
                        // When all the packages have been spawned, trigger GameOver

                    }
                    timer = 0;


                    if (totalPackagesDelivered >= 3)
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

    private float timer = 0f;
    public float initialSpawnRate;
    public float currentSpawnRate;
    public float difficulty;
    private float levelTimer = 0f;
    public bool gamePlay = true;

    public GameObject endGamePanel;
    public ScoreManager scoreManager;
    private bool gameOverTriggered = false;
    public TextMeshProUGUI finalScoreText;

    private int totalPackagesDelivered = 0;
    public int deliveryGoal = 3; // Set this in Inspector or change it to your desired threshold

    void Start()
    {
        currentSpawnRate = initialSpawnRate;

        foreach (GameObject pkg in packageList)
        {
            for (int i = 0; i < countPerPackage; i++)
            {
                spawnQueue.Add(pkg);
            }
        }

        // Shuffle the queue
        for (int i = 0; i < spawnQueue.Count; i++)
        {
            GameObject temp = spawnQueue[i];
            int randIndex = UnityEngine.Random.Range(i, spawnQueue.Count);
            spawnQueue[i] = spawnQueue[randIndex];
            spawnQueue[randIndex] = temp;
        }
    }

    void Update()
    {
        if (gamePlay && !gameOverTriggered)
        {
            levelTimer += Time.deltaTime;
            currentSpawnRate = initialSpawnRate - (difficulty * levelTimer);

            if (timer < currentSpawnRate)
            {
                timer += Time.deltaTime;
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
                }

                timer = 0f;

                // Check for delivery goal
                if (totalPackagesDelivered >= deliveryGoal)
                {
                    gamePlay = false;
                    GameOver();
                }
            }
        }
    }

    public void NotifyPackageDelivered()
    {
        totalPackagesDelivered++;
        Debug.Log("Total packages delivered: " + totalPackagesDelivered);
    }

    void GameOver()
    {
        gameOverTriggered = true;
        endGamePanel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Game over");

        int finalScore = scoreManager.GetScore();
        finalScoreText.text = "" + finalScore;

        GameObject.FindWithTag("GameController").GetComponent<ScoreManager>().SubmitScore("Level1");
    }

    public void resetSpawnRate()
    {
        levelTimer = 0f;
        currentSpawnRate = initialSpawnRate;
    }
}
*/

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

    public float initialSpawnRate;
    public float currentSpawnRate;
    public float difficulty; // A small value like 0.1f
    private float timer = 0f;

    public bool gamePlay = true;
    private bool gameOverTriggered = false;
  //  private bool allPackagesDelivered = false;

    public GameObject endGamePanel;
    public ScoreManager scoreManager;
    public PackageManager deliverManager;
    public TextMeshProUGUI finalScoreText;
    public packageSpawnerScript1 spawnScript;
    private int totalDelivered = 0;
    public int deliveryGoal = 3;

    void Start()
    {
        currentSpawnRate = initialSpawnRate;

        foreach (GameObject pkg in packageList)
        {
            for (int i = 0; i < countPerPackage; i++)
            {
                spawnQueue.Add(pkg);
            }
        }

        for (int i = 0; i < spawnQueue.Count; i++)
        {
            GameObject temp = spawnQueue[i];
            int randIndex = UnityEngine.Random.Range(i, spawnQueue.Count);
            spawnQueue[i] = spawnQueue[randIndex];
            spawnQueue[randIndex] = temp;
        }
    }

    void Update()
    {
      
        if (gamePlay && !gameOverTriggered)
        {
            if (timer < currentSpawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                if (spawnIndex < spawnQueue.Count)
                {
                    Instantiate(spawnQueue[spawnIndex], transform.position, transform.rotation);
                    spawnIndex++;
                    currentSpawnRate = Mathf.Max(0.5f, currentSpawnRate - difficulty); // reduce rate but clamp
                }
                else
                {
                    Debug.Log("All packages have been spawned.");
                }

                timer = 0f;

    /*            if (deliverManager.GetDeliveredCount() == countPerPackage * packageList.Count)
                {
                    allPackagesDelivered = true;
                }

                if (allPackagesDelivered)
                {
                    gamePlay = false;
                    GameOver();
                } */
            }
        }
    }


public void NotifyPackageDelivered()
{
    totalDelivered++;
    Debug.Log("Total packages delivered: " + totalDelivered);

    if (totalDelivered >= deliveryGoal && !gameOverTriggered)
    {
        gamePlay = false;
        GameOver();
    }
}

    void GameOver()
    {
        gameOverTriggered = true;
        endGamePanel.SetActive(true);
        Time.timeScale = 0;

        int finalScore = scoreManager.GetScore();
        finalScoreText.text = "" + finalScore;

        spawnScript.resetSpawnRate();

        GameObject.FindWithTag("GameController").GetComponent<ScoreManager>().SubmitScore("Level1");
    }

    public void resetSpawnRate()
    {
        currentSpawnRate = initialSpawnRate;
    }
}
