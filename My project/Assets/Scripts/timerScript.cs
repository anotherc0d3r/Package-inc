using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timerScript : MonoBehaviour
{
    public float duration = 62;
    public float timeRemaining;
    public TextMeshProUGUI timerText;
    public bool gamePlay = true;
    public TextMeshProUGUI finalScoreText; 
    public GameObject endGamePanel;
    public ScoreManager scoreManager;
    
    private bool gameOverTriggered = false; // Flag to ensure GameOver() is called only once

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = duration;
    }

    void Update()
    {
        if (gamePlay && !gameOverTriggered)
        {
            if (timeRemaining > 0)
            {
                // DeltaTime is subtracted from timeRemaining
                timeRemaining -= Time.deltaTime;

                // Outputs timeRemaining to UI
                timerText.text = timeRemaining.ToString("0");
            }
            else
            {
                // When the timer hits zero, trigger GameOver
                gamePlay = false;
                GameOver();
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
    }
}
