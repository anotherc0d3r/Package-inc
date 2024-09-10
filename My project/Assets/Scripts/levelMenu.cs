using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   
using TMPro;
public class levelMenu : MonoBehaviour
{

    public TextMeshProUGUI highScoreText;

void Start() {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
}
    public Button[] buttons;
    // Unlock levels based on player progress 
    private void Awake()
    {
        // Get unlocked levels from player prefs
        int unlockedLevel = PlayerPrefs.GetInt("Unlocked level" , 1);
        Debug.Log("Unlocked Level: " + unlockedLevel);
        Debug.Log("Buttons Length: " + buttons.Length);
       // Lock all levels but 1 initialy 
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;

        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
// Loads level based on number "Level 1"
    public void openLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }


    public void loadMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}

