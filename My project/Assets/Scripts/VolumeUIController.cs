using UnityEngine;
using UnityEngine.UI;

public class VolumeUIController : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        // ✅ Set sliders to match AudioManager’s saved values
        if (audioManager.instance != null)
        {
            if (masterSlider != null)
                masterSlider.value = audioManager.instance.GetMasterVolume();

            if (musicSlider != null)
                musicSlider.value = audioManager.instance.GetMusicVolume();

            if (sfxSlider != null)
                sfxSlider.value = audioManager.instance.GetSFXVolume();
        }

        // ✅ Add listeners so moving the sliders updates AudioManager
        if (masterSlider != null)
            masterSlider.onValueChanged.AddListener(v => audioManager.instance.SetMasterVolume(v));

        if (musicSlider != null)
            musicSlider.onValueChanged.AddListener(v => audioManager.instance.SetMusicVolume(v));

        if (sfxSlider != null)
            sfxSlider.onValueChanged.AddListener(v => audioManager.instance.SetSFXVolume(v));
    }
}

