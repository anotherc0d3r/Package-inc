using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseLogic : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>().PauseMusic();
        Time.timeScale = 0;
        

    }
    public void Resume()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>().ResumeMusic();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }




}