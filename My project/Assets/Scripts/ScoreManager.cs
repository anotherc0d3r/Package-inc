using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Reference to the Text component
    public int score = 0;  // Initial score
    private int highScore = 0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("High Score", 0);
    }

    // Call this method to update the score
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        CheckHighScore();
    }

    public int GetScore()
    {
        return score;
    }


    public int GetHighScore()
    {
        return highScore;
    }
    // Update the score text on the screen
    private void UpdateScoreText()
    {
        scoreText.text = " " + score.ToString();
    }

    private void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            //Saves highscore between sessions
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    // Add new score to highscore list
    public void SubmitScore(string LevelName)
    {
        // Creates list to store highscores
        List<int> highScores = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            //  loads top 4 scores from player prefs
            highScores.Add(PlayerPrefs.GetInt(LevelName + "_highScore" + i, 0));
        }

        // Adds entry to list
        highScores.Add(score);

        // Sorts list 
        highScores.Sort((a, b) => b.CompareTo(a)); // sorts list into descending order

        // Save top 4 scores into player prefs
        for (int i = 0; i < 4; i++)
        {
            PlayerPrefs.SetInt(LevelName + "_highScore" + i, highScores[i]);
        }

        PlayerPrefs.Save();
        Debug.Log(highScores);
    }
}
