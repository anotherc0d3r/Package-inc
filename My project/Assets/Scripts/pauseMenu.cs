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
    Time.timeScale = 0;
}
public void Resume()
{
    pauseMenu.SetActive(false);
        Time.timeScale = 1;
}
public void Restart()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1;
}
public void Title()
{
    SceneManager.LoadScene("mainMenu");
    Time.timeScale = 1;
}
public void Levels()
{
    SceneManager.LoadScene("Level Pick");
    Time.timeScale = 1;
}
}
