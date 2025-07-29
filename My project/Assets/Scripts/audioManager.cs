using UnityEngine;
using UnityEngine.SceneManagement;

public class audioManager : MonoBehaviour
{
    public static audioManager instance;

    [Header("--------Audio Sources--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
   


    [Header("--------Audio Clips--------")]
    public AudioClip backgroundMainMenu;
    public AudioClip backgroundLevel;
    public AudioClip packageThud;
    public AudioClip levelCompleteSFX;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);


            DontDestroyOnLoad(gameObject.transform.root.gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        }
    
    private void Start()
{
    if (!musicSource.isPlaying)
    {
      //  SceneManager.sceneLoaded += OnSceneLoaded;
        PlaySceneMusic(SceneManager.GetActiveScene().name);
    }
}


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name); // 🐞 log to confirm it's firing
        PlaySceneMusic(scene.name);
    }

    private void PlaySceneMusic(string sceneName)
    {
        AudioClip clipToPlay = null;

         if (sceneName == "mainMenu" || sceneName == "Level Pick" || sceneName == "howToPlay") 
        {
            clipToPlay = backgroundMainMenu;
        }
        else if (sceneName == "Level 1" || sceneName == "Level 2")
        {
            clipToPlay = backgroundLevel;
        }

        if (clipToPlay != null && musicSource.clip != clipToPlay)
        {
            musicSource.Stop(); // 💥 stop any currently playing music
            musicSource.clip = clipToPlay;
            musicSource.Play();
        }
    }
    
 

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);

        Debug.Log("Playing SFX: " + clip.name + " | Time: " + Time.time + " | Scene: " + SceneManager.GetActiveScene().name);
    }

    public void PauseMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Pause();
    }

    public void ResumeMusic()
    {
        if (!musicSource.isPlaying)
            musicSource.UnPause();
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
    }
}
