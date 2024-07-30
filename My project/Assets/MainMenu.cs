using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Animator transition;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadLevel(int levelIndex) {
        //Play animation
        transition.SetTrigger("Start");
        // Wait

        //Load Scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
