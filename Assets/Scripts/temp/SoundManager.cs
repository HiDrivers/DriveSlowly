using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider backgroundVolumeSlider;
    public Slider effectVolumeSlider;

    public AudioSource backgroundAudioSource;
    public AudioSource effectAudioSource;

    public event Action OnPlayEffectSound;
    public event Action OnPlayBackgroundSound;

    private void Awake()
    {
        masterVolumeSlider.onValueChanged.AddListener(value => SetMasterVolume(value));
        backgroundVolumeSlider.onValueChanged.AddListener(value => SetBackgroundVolume(value));
        effectVolumeSlider.onValueChanged.AddListener(value => SetEffectVolume(value));
    }

    private void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        backgroundVolumeSlider.value = PlayerPrefs.GetFloat("BackgroundVolume", 1.0f);
        effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1.0f);

        backgroundAudioSource.clip = Resources.Load<AudioClip>("BackgroundTest");
        effectAudioSource.clip = Resources.Load<AudioClip>("EffectTest");

        backgroundAudioSource.Play();

        UpdateVolumes();
    }

    public void SetMasterVolume(float volume)
    {
        masterVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();

        UpdateVolumes();

        Debug.Log("Master Volume: " + volume);
    }

    public void SetBackgroundVolume(float volume)
    {
        backgroundVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("BackgroundVolume", volume);
        PlayerPrefs.Save();

        UpdateBackgroundVolume();

        Debug.Log("Background Volume: " + volume);
    }

    public void SetEffectVolume(float volume)
    {
        effectVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("EffectVolume", volume);
        PlayerPrefs.Save();

        UpdateEffectVolume();

        Debug.Log("Effect Volume: " + volume);
    }

    public void UpdateVolumes()
    {
        backgroundAudioSource.volume = masterVolumeSlider.value * backgroundVolumeSlider.value;
        effectAudioSource.volume = masterVolumeSlider.value * effectVolumeSlider.value;

        OnPlayBackgroundSound?.Invoke();
        OnPlayEffectSound?.Invoke();
    }

    public void UpdateBackgroundVolume()
    {
        backgroundAudioSource.volume = masterVolumeSlider.value * backgroundVolumeSlider.value;
        OnPlayBackgroundSound?.Invoke();
    }

    public void UpdateEffectVolume()
    {
        effectAudioSource.volume = masterVolumeSlider.value * effectVolumeSlider.value;
        OnPlayEffectSound?.Invoke();
    }
}

