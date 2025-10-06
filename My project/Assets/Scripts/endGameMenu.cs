using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endGameMenu : MonoBehaviour
{
    [SerializeField] GameObject endGamePanel;
    [SerializeField] GameObject nextButton;  // 👈 assign in Inspector
    [SerializeField] int requiredScoreForNext; // 👈 set required score for NEXT level
    [SerializeField] string currentLevelName;  // 👈 e.g. "Level 1"
    [SerializeField] string nextLevelName;     // 👈 e.g. "Level 2"
    [SerializeField] GameObject levelComplete;  // 👈 assign in Inspector
    [SerializeField] GameObject almostThere;  // 👈 assign in Inspector
    private int lastFinalScore = 0;

  /*  public void ShowEndMenu()
      {
          // Save the latest score before showing the panel
          ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
          if (scoreManager != null)
          {
              scoreManager.SubmitScore(SceneManager.GetActiveScene().name);
          }
      } */
    private void OnEnable()
    {
        ShowNextButtonIfUnlocked();
    }
    
    public void SetFinalScore(int score)
{
    lastFinalScore = score;
    ShowNextButtonIfUnlocked(); // re-check immediately with the latest score
}
/*
      private void ShowNextButtonIfUnlocked()
    {
        int highScore = PlayerPrefs.GetInt("HighScore_" + currentLevelName, 0);

        if (highScore >= requiredScoreForNext)
        {
            if (nextButton != null)
                nextButton.SetActive(true);
            Debug.Log("Next button Active, score reached");
        }
        else
        {
            if (nextButton != null)
                nextButton.SetActive(false);
            Debug.Log("Next button Not active, score not reached");
        }
    }
*/
    private void ShowNextButtonIfUnlocked()
{
    int savedHighScore = PlayerPrefs.GetInt("HighScore_" + currentLevelName, 0);
    int effectiveScore = Mathf.Max(savedHighScore, lastFinalScore); // 👈 ensures current run counts

    if (effectiveScore >= requiredScoreForNext)
    {
        if (nextButton != null)
            nextButton.SetActive(true);
        if(levelComplete != null)
            levelComplete.SetActive(true);
        if(almostThere != null)
            almostThere.SetActive(false);

        Debug.Log("Next button Active, score reached");
    }
    else
    {
        if (nextButton != null)
            nextButton.SetActive(false);
            if (almostThere != null)
            almostThere.SetActive(true);
        if (levelComplete != null)
            levelComplete.SetActive(false);
  
        Debug.Log("Next button Not active, score not reached");
    }
}


public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}

