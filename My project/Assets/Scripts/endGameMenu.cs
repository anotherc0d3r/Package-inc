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

      private void ShowNextButtonIfUnlocked()
    {
        int highScore = PlayerPrefs.GetInt("HighScore_" + currentLevelName, 0);

        if (highScore >= requiredScoreForNext)
        {
            if (nextButton != null)
                nextButton.SetActive(true);
        }
        else
        {
            if (nextButton != null)
                nextButton.SetActive(false);
        }
    }

public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}

