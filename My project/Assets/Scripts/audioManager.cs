using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;




public class audioManager : MonoBehaviour
{
    [Header("--------Audio Source--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource backgroundSource;


    [Header("--------Audio Clip--------")]
    public AudioClip background;
    public AudioClip backgroundMainMenu;
    public AudioClip packageThud;

   private void Start()
{
    // Optional: Persist the audioManager between scenes
    DontDestroyOnLoad(gameObject);

    string currentScene = SceneManager.GetActiveScene().name;

    if (currentScene == "MainMenu")
    {
        musicSource.clip = backgroundMainMenu;
    }
    else
    {
        musicSource.clip = background;
    }

    musicSource.Play();
}

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }


    public void PauseMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }
    }

    public void ResumeMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.UnPause();
        }


    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

/*  private void Start()
    {
        musicSource.clip = backgroundMainMenu;
        musicSource.Play();
    }*/
}