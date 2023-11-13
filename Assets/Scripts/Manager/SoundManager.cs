using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider effectVolumeSlider;
    public Slider backgroundVolumeSlider; // Added background volume slider

    public AudioSource backgroundAudioSource;
    public AudioSource effectAudioSource;

    public event Action OnPlayEffectSound;
    public event Action OnStopEffectSound;

    private void Awake()
    {
        masterVolumeSlider.onValueChanged.AddListener(value => SetMasterVolume(value));
        effectVolumeSlider.onValueChanged.AddListener(value => SetEffectVolume(value));
        backgroundVolumeSlider.onValueChanged.AddListener(value => SetBackgroundVolume(value)); // Added listener for background volume slider
    }

    private void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1.0f);
        backgroundVolumeSlider.value = PlayerPrefs.GetFloat("BackgroundVolume", 1.0f); // Set initial background volume

        backgroundAudioSource.clip = Resources.Load<AudioClip>("BackGroundTest");
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

    public void SetEffectVolume(float volume)
    {
        effectVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("EffectVolume", volume);
        PlayerPrefs.Save();

        UpdateEffectVolume();

        Debug.Log("Effect Volume: " + volume);
    }

    public void SetBackgroundVolume(float volume)
    {
        backgroundVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("BackgroundVolume", volume);
        PlayerPrefs.Save();

        UpdateBackgroundVolume();

        Debug.Log("Background Volume: " + volume);
    }

    public void UpdateVolumes()
    {
        backgroundAudioSource.volume = masterVolumeSlider.value * backgroundVolumeSlider.value; // Adjusted background volume
        effectAudioSource.volume = masterVolumeSlider.value;

        OnPlayEffectSound?.Invoke();
    }

    public void UpdateEffectVolume()
    {
        effectAudioSource.volume = effectVolumeSlider.value;
        OnPlayEffectSound?.Invoke();
    }

    public void UpdateBackgroundVolume()
    {
        backgroundAudioSource.volume = masterVolumeSlider.value * backgroundVolumeSlider.value; // Adjusted background volume
    }
}



























