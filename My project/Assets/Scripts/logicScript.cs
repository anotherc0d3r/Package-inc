using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
public class logicScript : MonoBehaviour
{
    public int score;
    public Text scoreText;

        [ContextMenu("Increase score")]
        public void addScore()
        {
            score = score + 1;
            scoreText.text = score.ToString();
        }
}
