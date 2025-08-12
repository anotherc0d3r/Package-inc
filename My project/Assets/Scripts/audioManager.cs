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

        if (sceneName == "mainMenu" || sceneName == "Level Pick" || sceneName == "howToPlay" || sceneName == "ScoreBoard")
            clipToPlay = backgroundMainMenu;
        else if (sceneName == "Level 1" || sceneName == "Level 2" || sceneName == "Level 3")
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
