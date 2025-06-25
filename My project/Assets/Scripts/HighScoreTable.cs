using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class HighScoreTable : MonoBehaviour
{
    // Declare highscores to be displayed on table
    private int highScore1 = 0;
    private int highScore2 = 0;
    private int highScore3 = 0;
    private int highScore4 = 0;

    public TextMeshProUGUI highScore1Text;
    public TextMeshProUGUI highScore2Text;
    public TextMeshProUGUI highScore3Text;
    public TextMeshProUGUI highScore4Text;

    // Start is called before the first frame update
    void Start()
    {
        // Display scores in UI
        highScore1Text.text = highScore1.ToString("0");
        highScore1Text.text = highScore2.ToString("0");
        highScore1Text.text = highScore3.ToString("0");
        highScore1Text.text = highScore4.ToString("0");
    }
}
