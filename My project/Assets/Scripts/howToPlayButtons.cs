using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class howToPlayButtons : MonoBehaviour
{
    [SerializeField] GameObject howToPlay;
    [SerializeField] GameObject GameUI;
/*    public void Resume()
    {

        GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>().ResumeMusic();
        howToPlay.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1;
        Debug.Log("Level unpaused");
    }
  */
  public void Resume()
{
    Debug.Log("Resume() button clicked");

    GameObject audioObj = GameObject.FindGameObjectWithTag("Audio");
    if (audioObj != null)
    {
        var manager = audioObj.GetComponent<audioManager>();
        if (manager != null)
        {
            manager.ResumeMusic();
            Debug.Log("Audio resumed");
        }
        else
        {
            Debug.LogWarning("AudioManager component missing!");
        }
    }
    else
    {
        Debug.LogWarning("Audio object not found!");
    }

    if (howToPlay != null)
    {
        howToPlay.SetActive(false);
        Debug.Log("HowToPlay disabled");
    }
    else
    {
        Debug.LogWarning("howToPlay reference missing!");
    }

    if (GameUI != null)
    {
        GameUI.SetActive(true);
        Debug.Log("GameUI enabled");
    }
    else
    {
        Debug.LogWarning("GameUI reference missing!");
    }

    Time.timeScale = 1;
    Debug.Log("Time resumed");
}

}

