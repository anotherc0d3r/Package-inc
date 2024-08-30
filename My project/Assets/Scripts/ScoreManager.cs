using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Reference to the Text component
    public int score = 0;  // Initial score

    // Call this method to update the score
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // Update the score text on the screen
    private void UpdateScoreText()
    {
        scoreText.text = " " + score.ToString();
    }
}
