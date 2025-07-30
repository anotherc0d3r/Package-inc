using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PackageType2
{
    public string name;
    public GameObject prefab;
    public int count;
}

public class packageSpawnerScript2 : MonoBehaviour
{
    public List<PackageType2> packageTypes = new List<PackageType2>(); // New structured list

    private List<GameObject> spawnQueue = new List<GameObject>();
    private int spawnIndex = 0;

    public float initialSpawnRate;
    public float currentSpawnRate;
    public float difficulty;
    private float timer = 0f;

    public bool gamePlay = true;
    private bool gameOverTriggered = false;

    public GameObject endGamePanel;
    public ScoreManager scoreManager;
    public TextMeshProUGUI finalScoreText;
    public packageSpawnerScript2 spawnScript;

    private int totalDelivered = 0;
    public int deliveryGoal; // Automatically calculated in Start()

    void Start()
    {
        currentSpawnRate = initialSpawnRate;

        spawnQueue.Clear();
        int totalSpawnCount = 0;

        // Build the spawn queue
        foreach (PackageType2 type in packageTypes)
        {
            for (int i = 0; i < type.count; i++)
            {
                spawnQueue.Add(type.prefab);
                totalSpawnCount++;
            }
        }

        // Shuffle the queue
        for (int i = 0; i < spawnQueue.Count; i++)
        {
            GameObject temp = spawnQueue[i];
            int randIndex = Random.Range(i, spawnQueue.Count);
            spawnQueue[i] = spawnQueue[randIndex];
            spawnQueue[randIndex] = temp;
        }

        // Set delivery goal
        deliveryGoal = totalSpawnCount;
    }

    void Update()
    {
        if (!gamePlay || gameOverTriggered) return;

        timer += Time.deltaTime;
        currentSpawnRate = Mathf.Max(0.5f, currentSpawnRate); // Clamp spawn rate

        if (timer >= currentSpawnRate)
        {
            if (spawnIndex < spawnQueue.Count)
            {
                Instantiate(spawnQueue[spawnIndex], transform.position, transform.rotation);
                spawnIndex++;

                currentSpawnRate = Mathf.Max(0.5f, currentSpawnRate - difficulty);
                timer = 0f;
            }
            else
            {
                Debug.Log("All packages have been spawned.");
            }
        }
    }

    public void NotifyPackageDelivered()
    {
        totalDelivered++;
        Debug.Log("Total packages delivered: " + totalDelivered);

        if (totalDelivered >= deliveryGoal && !gameOverTriggered)
        {
            StartCoroutine(DelayedGameOver());
        }
    }

    private System.Collections.IEnumerator DelayedGameOver()
    {
        gameOverTriggered = true;
        yield return new WaitForSeconds(0.6f);
        gamePlay = false;
        GameOver();
    }

    void GameOver()
    {
        endGamePanel.SetActive(true);
        Time.timeScale = 0;

        int finalScore = scoreManager.GetScore();
        finalScoreText.text = "" + finalScore;

        audioManager.instance.PlaySFX(audioManager.instance.levelCompleteSFX);

        if (spawnScript != null)
        {
            spawnScript.resetSpawnRate();
        }

        GameObject gc = GameObject.FindWithTag("GameController");
        if (gc != null)
        {
            ScoreManager sm = gc.GetComponent<ScoreManager>();
            if (sm != null)
            {
                sm.SubmitScore("Level2");
            }
        }
        levelComplete(2);
        Debug.Log("Unlockedlevel " + PlayerPrefs.GetInt("Unlockedlevel"));
        
        Debug.Log("Game over");
    }

    public void resetSpawnRate()
    {
        currentSpawnRate = initialSpawnRate;
    }

        public void levelComplete(int levelCompleted)
    {
        PlayerPrefs.SetInt("Unlockedlevel", levelCompleted);
        PlayerPrefs.Save();
    }

}
