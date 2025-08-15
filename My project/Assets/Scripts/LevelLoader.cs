using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour

{



    public Animator transition;
    public float transitionTime = 1f;
 private void Awake()
{
    SceneManager.sceneLoaded += OnSceneLoaded;
}

private void Start()
{
    AssignTransitionIfMissing();
}

private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    AssignTransitionIfMissing();
}

//Main Menu to Level Pick
    public void LoadLevelPick()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

// Main Menu to How To Play
    public void LoadHowToPlay()
    {
 
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
    }

// How to Play to Main Menu
    public void LoadMainMenu2()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 2));
    }
// Level Pick to Main Menu
           public void LoadMainMenu1()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

//Level 1 to Main Menu
    public void LoadMainMenu3()
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 3));
        Time.timeScale = 1;
    }
// Level 2 to Main Menu
         public void LoadMainMenu4()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 4));
        Time.timeScale = 1;
    }
// Level 3 to MainMenu
    public void LoadMainMenu5()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 6));
        Time.timeScale = 1;
    }
// Level 1 to Level Pick
    public void LoadLevelPick2()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 2));
        Time.timeScale = 1;
    }
//  Level 2 to level pick
    public void LoadLevelPick3()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 3));
        Time.timeScale = 1;
    }
// Scoreboard to level Pick 
    public void LoadLevelPick4()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 4));
        Time.timeScale = 1;
    }
// Level 3 to level Pick 
    public void LoadLevelPick5()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 5));
        Time.timeScale = 1;
    }
// Level Pick to level 1
    public void LoadLevel1()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
        Time.timeScale = 1;
    }
// Level 1 to Level 2
    public void LoadLevel2()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        Time.timeScale = 1;
    }
// Level 2 to Level 3
    public void LoadLevel3()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
        Time.timeScale = 1;
    }



private void AssignTransitionIfMissing()
    {
        if (transition == null)
        {
            GameObject transitionObj = GameObject.Find("BoxChange"); // Replace with your actual GameObject name
            if (transitionObj != null)
            {
                transition = transitionObj.GetComponent<Animator>();
            }
            else
            {
                Debug.LogError("Transition Animator object not found in scene: " + SceneManager.GetActiveScene().name);
            }
        }
    }


public    IEnumerator LoadLevel(int levelIndex) {
        //Play animation
        transition.SetTrigger("Start");
    
        // Wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        SceneManager.LoadScene(levelIndex);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("howToPlay");
    }

     public void LoadScoreBoard()
    {
        //    Debug.Log("Transition is: " + transition);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 4));
         Time.timeScale = 1;
    } 

    public void QuitGame()
    {
        Application.Quit();
    }

}
