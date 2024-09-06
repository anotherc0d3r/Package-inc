using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timerScript : MonoBehaviour
{
    public float duration = 60;
    public float timeRemaning;
    public TextMeshProUGUI timerText;
    public bool gamePlay = true;
    public Text finalScoreText; 
        public GameObject endGamePanel;

        public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaning = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaning > 0)
        {
        // DeltaTime is subtracted from time remaning
        timeRemaning = timeRemaning - Time.deltaTime;
       // Debug.Log("Time Remaning " + timeRemaning);
        // Outputs timeRemaning to UI
        timerText.text = timeRemaning.ToString("0");
       // Debug.Log("Timer display " + timerText.text);
        }else{
        EndGame();
        }
    
    }

    void EndGame() {
        gamePlay = false;
        endGamePanel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Game over"); 
// Get the final score from ScoreManager
        int finalScore = scoreManager.GetScore();
        finalScoreText.text = "" + finalScore;
    }
}
