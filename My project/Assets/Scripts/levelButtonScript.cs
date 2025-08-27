/*using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public string levelName; // e.g. "Level 2"
    public string previousLevelName; // e.g. "Level 1"
    public int requiredScore; // points needed in previous level
   public Button button; // Button component
    public GameObject lockIcon; // optional visual
   public SpriteRenderer spriteRenderer; // optional sprite swap
    public Sprite unlockedSprite;
    public Sprite lockedSprite;

    void Start()
{
    bool isUnlocked;

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

    // Update the button UI
    if (button != null) button.interactable = isUnlocked;
    if (lockIcon != null) lockIcon.SetActive(!isUnlocked);
    if (spriteRenderer != null) spriteRenderer.sprite = isUnlocked ? unlockedSprite : lockedSprite;

    Debug.Log(levelName + " unlocked? " + isUnlocked);
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
*/

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
