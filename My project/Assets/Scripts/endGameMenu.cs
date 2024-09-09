using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameMenu : MonoBehaviour
{
    [SerializeField] GameObject endGamePanel;
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
