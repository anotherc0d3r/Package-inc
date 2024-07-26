using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    public float duration = 60;
    public float timeRemaning;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaning = duration;
    }

    // Update is called once per frame
    void Update()
    {
        // DeltaTime is subtracted from time remaning
        timeRemaning = timeRemaning - Time.deltaTime;
        Debug.Log("Time Remaning " + timeRemaning);
        // Outputs timeRemaning to UI
        timerText.text ="Time : " + timeRemaning.ToString("0.0");
        Debug.Log("Timer display " + timerText.text);
    }
}
