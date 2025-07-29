using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour

{
    public Animator transition;
    public float transitionTime = 1f;
 
  
    public void LoadLevelPick()
    {
        //    Debug.Log("Transition is: " + transition);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

        public void LoadHowToPlay()
    {
    //    Debug.Log("Transition is: " + transition);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
    }

        public void LoadMainMenu2()
    {
    //    Debug.Log("Transition is: " + transition);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex -2));
    }

           public void LoadMainMenu1()
    {
    //    Debug.Log("Transition is: " + transition);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex -1));
    }

             public void LoadLevel1()
    {
    //    Debug.Log("Transition is: " + transition);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +2));
    }

    public void LoadMainMenu3()
    {
        //    Debug.Log("Transition is: " + transition);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 3));
         Time.timeScale = 1;
    }

    public void LoadLevelPick2()
    {
        //    Debug.Log("Transition is: " + transition);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 2));
        Time.timeScale = 1;
    }

       public void LoadMainMenu4()
    {
        //    Debug.Log("Transition is: " + transition);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 4));
        Time.timeScale = 1;
    }

         public void LoadLevelPick3()
    {
        //    Debug.Log("Transition is: " + transition);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 3));
        Time.timeScale = 1;
    }

         public void LoadLevel2()
    {
        //    Debug.Log("Transition is: " + transition);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        Time.timeScale = 1;
    }



    IEnumerator LoadLevel(int levelIndex) {
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
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
         Time.timeScale = 1;
    } 

    public void QuitGame()
    {
        Application.Quit();
    }

}
