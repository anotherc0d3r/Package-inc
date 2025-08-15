using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public SpriteRenderer levelSprite2;
    public Sprite levelSpriteUnlocked2;
    public SpriteRenderer levelSprite3;
    public Sprite levelSpriteUnlocked3;

    public int scoreToUnlockLevel2 = 3;
    public int scoreToUnlockLevel3 = 6;

    void Awake()
    {
        // Level 1 always unlocked
    PlayerPrefs.SetInt("Level 1_Unlocked", 1);
PlayerPrefs.Save();

        // Check previous level high scores
        UnlockLevelIfScoreMet("Level 1", "Level 2", scoreToUnlockLevel2, levelSprite2, levelSpriteUnlocked2);
        UnlockLevelIfScoreMet("Level 2", "Level 3", scoreToUnlockLevel3, levelSprite3, levelSpriteUnlocked3);
    }

    void UnlockLevelIfScoreMet(string prevLevel, string currentLevel, int requiredScore, SpriteRenderer buttonRenderer, Sprite unlockedSprite)
    {
        int prevHighScore = PlayerPrefs.GetInt("HighScore_" + prevLevel, 0);
        if (prevHighScore >= requiredScore)
        {
            PlayerPrefs.SetInt(currentLevel + "_Unlocked", 1);
            if (buttonRenderer != null && unlockedSprite != null)
                buttonRenderer.sprite = unlockedSprite;
        }
        else
        {
            PlayerPrefs.SetInt(currentLevel + "_Unlocked", 0);
        }
        PlayerPrefs.Save();
    }
}
