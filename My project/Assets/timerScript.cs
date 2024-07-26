using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    public float duration = 60;
    public float timeRemaning;
    public bool isCountingDown = false;
    public Text timer;
    private int time;


    // Start is called before the first frame update
    void Start()
    {
      if(!isCountingDown)  {
        isCountingDown = true;
        timeRemaning = duration;
      }
    }

    // Update is called once per frame
    void Update()
    {
        time = (int)Time.time;
        timeRemaning = timeRemaning - time;
        Debug.Log("Time Remaning " + timeRemaning);
        Debug.Log("Time " + time);
    }
}
