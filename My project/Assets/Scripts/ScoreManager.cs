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
        Debug.Log("Score.1: " + score);
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
    public void SubmitScore(string levelName)
{
    List<int> highScores = new List<int>();

    for (int i = 0; i < 4; i++)
        highScores.Add(PlayerPrefs.GetInt(levelName + "_highScore" + i, 0));

    highScores.Add(score);
    highScores.Sort((a, b) => b.CompareTo(a));

    for (int i = 0; i < 4; i++)
        PlayerPrefs.SetInt(levelName + "_highScore" + i, highScores[i]);

    // Also store the top score for easy access
    PlayerPrefs.SetInt("HighScore_" + levelName, highScores[0]);
    PlayerPrefs.Save();
}

}
