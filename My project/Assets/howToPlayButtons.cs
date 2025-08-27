using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class howToPlayButtons : MonoBehaviour
{
        [SerializeField] GameObject howToPlay;
    public void Resume()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>().ResumeMusic();
        howToPlay.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Level unpaused");
    }
  
}

