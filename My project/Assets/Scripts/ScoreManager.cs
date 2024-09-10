using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Reference to the Text component
    public int score = 0;  // Initial score
    private int highScore = 0;

    private void Start() {
        highScore = PlayerPrefs.GetInt("High Score", 0);
    }

    // Call this method to update the score
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        CheckHighScore();
    }

    public int GetScore() {
        return score;
    }

    public int GetHighScore() {
        return highScore;
    }
    // Update the score text on the screen
    private void UpdateScoreText()
    {
        scoreText.text = " " + score.ToString();
    }

    private void CheckHighScore() {
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}
