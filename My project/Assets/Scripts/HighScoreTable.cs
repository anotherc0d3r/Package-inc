using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class HighScoreTable : MonoBehaviour
{
    // Declare highscores to be displayed on table

    public TextMeshProUGUI highScore0Text;
    public TextMeshProUGUI highScore1Text;
    public TextMeshProUGUI highScore2Text;
    public TextMeshProUGUI highScore3Text;


    public string LevelName = "Level1";

    // Start is called before the first frame update
    void Start()
    {
        // Display scores in UI
        highScore0Text.text = PlayerPrefs.GetInt(LevelName + "_highScore0", 0).ToString("0");
        highScore1Text.text = PlayerPrefs.GetInt(LevelName + "_highScore1", 0).ToString("0");
        highScore2Text.text = PlayerPrefs.GetInt(LevelName + "_highScore2", 0).ToString("0");
        highScore3Text.text = PlayerPrefs.GetInt(LevelName + "_highScore3", 0).ToString("0");
        Debug.Log(highScore0Text);


    }
}
