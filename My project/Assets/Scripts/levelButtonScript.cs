using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string levelName;           // Scene to load
    public string previousLevelName;   // Previous level name
    public int requiredScore;          // Score required to unlock
    public SpriteRenderer spriteRenderer;
    public Sprite unlockedSprite;
    public Sprite lockedSprite;

    private bool isUnlocked;

    void Start()
    {
        // Level 1 is always unlocked
        if (string.IsNullOrEmpty(previousLevelName))
        {
            isUnlocked = true;
        }
        else
        {
            int prevHighScore = PlayerPrefs.GetInt("HighScore_" + previousLevelName, 0);
            isUnlocked = prevHighScore >= requiredScore;
        }

        // Set the correct sprite
        if (spriteRenderer != null)
            spriteRenderer.sprite = isUnlocked ? unlockedSprite : lockedSprite;
    }

    void OnMouseDown()
    {
        if (isUnlocked)
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.Log("Level locked! Score " + requiredScore + " needed in " + previousLevelName);
        }
    }
}
