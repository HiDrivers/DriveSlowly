using UnityEngine;
using UnityEngine.UI;

public class PrefabVolumeController : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider backgroundVolumeSlider;
    public Slider effectVolumeSlider;

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();

        if (masterVolumeSlider != null)
        {
            masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        }

        if (backgroundVolumeSlider != null)
        {
            backgroundVolumeSlider.onValueChanged.AddListener(SetBackgroundVolume);
        }

        if (effectVolumeSlider != null)
        {
            effectVolumeSlider.onValueChanged.AddListener(SetEffectVolume);
        }
    }

    public void SetMasterVolume(float volume)
    {
        if (soundManager != null)
        {
            soundManager.SetMasterVolume(volume);
        }
    }

    public void SetBackgroundVolume(float volume)
    {
        if (soundManager != null)
        {
            soundManager.SetBackgroundVolume(volume);
        }
    }

    public void SetEffectVolume(float volume)
    {
        if (soundManager != null)
        {
            soundManager.SetEffectVolume(volume);
        }
    }
}

