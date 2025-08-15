using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class HighScoreTable : MonoBehaviour
{
    // Declare highscore text array to be displayed on table

    public TextMeshProUGUI[] highScoreTexts;

    public string LevelName;

    // Start is called before the first frame update
    void Start()
    {
    // Display scores in UI
        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            // Set highscores and assign to array
            int score = PlayerPrefs.GetInt(LevelName + "_highScore" + i, 0);
            highScoreTexts[i].text = score.ToString("0");
            Debug.Log("High Score" + i + score);
        }




        PlayerPrefs.SetInt("Level2_highScore0", 10);
        // Display scores in UI
        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            // Set highscores and assign to array
            int score = PlayerPrefs.GetInt(LevelName + "_highScore" + i, 0);
            highScoreTexts[i].text = score.ToString("0");
            Debug.Log("High Score" + i + score);
        }

   PlayerPrefs.SetInt("Level3_highScore0", 10);
        // Display scores in UI
        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            // Set highscores and assign to array
            int score = PlayerPrefs.GetInt(LevelName + "_highScore" + i, 0);
            highScoreTexts[i].text = score.ToString("0");
            Debug.Log("High Score" + i + score);
        }

    }
}
