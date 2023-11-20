using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider backgroundVolumeSlider;
    public Slider effectVolumeSlider;

    private AudioSource[] sceneBackgroundAudioSources;
    private float masterVolume = 1.0f;

    private void Awake()
    {
        sceneBackgroundAudioSources = new AudioSource[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < sceneBackgroundAudioSources.Length; i++)
        {
            sceneBackgroundAudioSources[i] = gameObject.AddComponent<AudioSource>();
        }

        LoadVolumesFromPlayerPrefs();
        ApplyMasterVolume();

        masterVolumeSlider.onValueChanged.AddListener((value) => { SetMasterVolume(value); });
        backgroundVolumeSlider.onValueChanged.AddListener((value) => { SetBackgroundVolume(value); });
        effectVolumeSlider.onValueChanged.AddListener((value) => { SetEffectVolume(value); });

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplyMasterVolume();
        LoadAndPlaySceneBackground();
    }

    private void LoadVolumesFromPlayerPrefs()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        backgroundVolumeSlider.value = PlayerPrefs.GetFloat("BackgroundVolume", 1.0f);
        effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1.0f);
    }

    private void ApplyMasterVolume()
    {
        masterVolume = masterVolumeSlider.value;
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.Save();

        ApplyVolumes();
    }

    private void ApplyVolumes()
    {
        for (int i = 0; i < sceneBackgroundAudioSources.Length; i++)
        {
            if (sceneBackgroundAudioSources[i] != null)
            {
                sceneBackgroundAudioSources[i].volume = masterVolume * backgroundVolumeSlider.value;
            }
        }
    }

    private void LoadAndPlaySceneBackground()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string backgroundMusicName = sceneName + "Background";

        AudioClip sceneBackground = Resources.Load<AudioClip>(backgroundMusicName);

        if (sceneBackground != null)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (sceneIndex < sceneBackgroundAudioSources.Length)
            {
                sceneBackgroundAudioSources[sceneIndex].clip = sceneBackground;
                sceneBackgroundAudioSources[sceneIndex].loop = true;
                sceneBackgroundAudioSources[sceneIndex].volume = masterVolume * backgroundVolumeSlider.value;
                sceneBackgroundAudioSources[sceneIndex].Play();
            }
        }
    }

    public void SetMasterVolume(float volume)
    {
        masterVolumeSlider.value = volume;
        ApplyMasterVolume();
    }

    public void SetBackgroundVolume(float volume)
    {
        backgroundVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("BackgroundVolume", volume);
        PlayerPrefs.Save();
        ApplyVolumes();
    }

    public void SetEffectVolume(float volume)
    {
        effectVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("EffectVolume", volume);
        PlayerPrefs.Save();
        // 여기에 효과음 볼륨 조절을 위한 처리를 추가할 수 있습니다.
    }

    public void PlayItemSound(string itemName)
    {
        int audioSourceIndex = -1;

        switch (itemName)
        {
            case "booster":
                audioSourceIndex = 0;
                break;
            case "coffee":
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
            case "sojuCleaner":
                audioSourceIndex = 6;
                break;
            default:
                Debug.LogWarning("No sound for this item.");
                break;
        }

        if (audioSourceIndex >= 0 && audioSourceIndex < sceneBackgroundAudioSources.Length)
        {
            sceneBackgroundAudioSources[audioSourceIndex].Play();
        }
        else
        {
            Debug.LogWarning("Invalid audio source index");
        }
    }
}



































