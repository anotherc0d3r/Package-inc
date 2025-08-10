/*
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
    public AudioClip PackageOpened;


public void SetMusicVolume(float volume)
{
    if (musicSource != null)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }
}

    public void SetSFXVolume(float volume)
    {
        if (SFXSource != null)
        {
            SFXSource.volume = volume;
            PlayerPrefs.SetFloat("SFXVolume", volume);
            PlayerPrefs.Save();
        }
    }

public void SetMasterVolume(float volume)
{
    if (SFXSource != null)
    {
        SFXSource.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }
}

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

        
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        musicSource.volume = musicVolume;
        SFXSource.volume = sfxVolume;

        if (musicSlider != null)
            musicSlider.value = musicVolume;

        if (sfxSlider != null)
            sfxSlider.value = sfxVolume;

        if (masterSlider != null)
            sfxSlider.value = masterVolume;


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
*/
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
    public AudioClip PackageOpened;

    private float masterVolume = 1f;
    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;

            // Load saved volumes
            masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
            musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

            ApplyVolumes();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!musicSource.isPlaying)
        {
            PlaySceneMusic(SceneManager.GetActiveScene().name);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlaySceneMusic(scene.name);
    }

    private void PlaySceneMusic(string sceneName)
    {
        AudioClip clipToPlay = null;

        if (sceneName == "mainMenu" || sceneName == "Level Pick" || sceneName == "howToPlay")
            clipToPlay = backgroundMainMenu;
        else if (sceneName == "Level 1" || sceneName == "Level 2")
            clipToPlay = backgroundLevel;

        if (clipToPlay != null && musicSource.clip != clipToPlay)
        {
            musicSource.Stop();
            musicSource.clip = clipToPlay;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
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

    // 🧠 Apply all volume settings with master volume
    private void ApplyVolumes()
    {
        musicSource.volume = musicVolume * masterVolume;
        SFXSource.volume = sfxVolume * masterVolume;
    }

    // 🎚 Called by sliders (from UI)
    public void SetMasterVolume(float value)
    {
        masterVolume = value;
        PlayerPrefs.SetFloat("MasterVolume", value);
        PlayerPrefs.Save();
        ApplyVolumes();
    }

    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
        ApplyVolumes();
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
        ApplyVolumes();
    }

    // 🔁 Optional getter if you want to sync UI sliders visually
    public float GetMusicVolume() => musicVolume;
    public float GetSFXVolume() => sfxVolume;
    public float GetMasterVolume() => masterVolume;
}
