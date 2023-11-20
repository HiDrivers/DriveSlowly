using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider backgroundVolumeSlider;
    public Slider effectVolumeSlider;

    public AudioSource backgroundAudioSource;
    public AudioSource[] effectAudioSources;

    private float masterVolume = 1.0f;

    private void Awake()
    {
        masterVolumeSlider.onValueChanged.AddListener((value) => { SetMasterVolume(value); });
        backgroundVolumeSlider.onValueChanged.AddListener((value) => { SetBackgroundVolume(value); });
        effectVolumeSlider.onValueChanged.AddListener((value) => { SetEffectVolume(value); });

        effectAudioSources = new AudioSource[7];
        for (int i = 0; i < effectAudioSources.Length; i++)
        {
            effectAudioSources[i] = gameObject.AddComponent<AudioSource>();
        }

        LoadAudioClips();
        LoadVolumesFromPlayerPrefs();
        ApplyMasterVolume();
    }

    private void LoadVolumesFromPlayerPrefs()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        backgroundVolumeSlider.value = PlayerPrefs.GetFloat("BackgroundVolume", 1.0f);
        effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1.0f);

        for (int i = 0; i < effectAudioSources.Length; i++)
        {
            float volume = PlayerPrefs.GetFloat("EffectVolume" + i, 1.0f);
            effectAudioSources[i].volume = volume;
        }
    }

    private void LoadAudioClips()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "SoundTest":
                backgroundAudioSource.clip = Resources.Load<AudioClip>("Scene1Background");
                break;
            case "Scene2":
                backgroundAudioSource.clip = Resources.Load<AudioClip>("Scene2Background");
                break;
            default:
                break;
        }

        backgroundAudioSource.Play();
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        ApplyMasterVolume();
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetBackgroundVolume(float volume)
    {
        backgroundAudioSource.volume = masterVolume * volume;
        PlayerPrefs.SetFloat("BackgroundVolume", volume);
    }

    public void SetEffectVolume(float volume)
    {
        for (int i = 0; i < effectAudioSources.Length; i++)
        {
            effectAudioSources[i].volume = masterVolume * volume;
            PlayerPrefs.SetFloat("EffectVolume" + i, volume);
        }
    }

    public void ApplyMasterVolume()
    {
        for (int i = 0; i < effectAudioSources.Length; i++)
        {
            effectAudioSources[i].volume = masterVolume * effectVolumeSlider.value;
            PlayerPrefs.SetFloat("EffectVolume" + i, effectVolumeSlider.value);
        }
        backgroundAudioSource.volume = masterVolume * backgroundVolumeSlider.value;
        PlayerPrefs.SetFloat("BackgroundVolume", backgroundVolumeSlider.value);
        // PlayerPrefs.SetFloat("MasterVolume", masterVolume); // 이 부분 주석 처리
    }

    public void UpdateVolumes()
    {
        SetMasterVolume(masterVolumeSlider.value);
        SetBackgroundVolume(backgroundVolumeSlider.value);
        SetEffectVolume(effectVolumeSlider.value);
        PlayerPrefs.Save();
    }

    public void PlayEffectSound(int audioSourceIndex)
    {
        if (audioSourceIndex < effectAudioSources.Length)
        {
            effectAudioSources[audioSourceIndex].Play();
        }
        else
        {
            Debug.LogWarning("Invalid audio source index");
        }
    }

    public void PlayItemSound(string itemName)
    {
        int audioSourceIndex = -1;

        switch (itemName)
        {
            case "booster":
                audioSourceIndex = 0;
                break;
            case "coffe":
                audioSourceIndex = 1;
                break;
            case "coin":
                audioSourceIndex = 2;
                break;
            case "pillow":
                audioSourceIndex = 3;
                break;
            case "smartphone":
                audioSourceIndex = 4;
                break;
            case "soju":
                audioSourceIndex = 5;
                break;
            case "sojucleaner":
                audioSourceIndex = 6;
                break;
            default:
                Debug.LogWarning("No sound for this item.");
                break;
        }

        if (audioSourceIndex != -1)
        {
            PlayEffectSound(audioSourceIndex);
        }
    }
}















