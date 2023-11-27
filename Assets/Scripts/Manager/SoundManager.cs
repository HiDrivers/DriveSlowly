using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    public Slider masterVolumeSlider;
    public Slider backgroundVolumeSlider;
    public Slider effectVolumeSlider;

    private AudioSource[] backgroundAudioSources;
    private AudioSource[] effectAudioSources;

    private new void Awake()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        backgroundAudioSources = new AudioSource[sceneCount];
        effectAudioSources = new AudioSource[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            backgroundAudioSources[i] = gameObject.AddComponent<AudioSource>();
            effectAudioSources[i] = gameObject.AddComponent<AudioSource>();
        }

        LoadVolumesFromPlayerPrefs();
        ApplyVolumes();

        masterVolumeSlider.onValueChanged.AddListener((value) => { SetMasterVolume(value); });
        backgroundVolumeSlider.onValueChanged.AddListener((value) => { SetBackgroundVolume(value); });
        effectVolumeSlider.onValueChanged.AddListener((value) => { SetEffectVolume(value); });

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopPreviousSceneBackground();
        LoadAndPlaySceneBackground();
    }

    private void StopPreviousSceneBackground()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex;

        for (int i = 0; i < backgroundAudioSources.Length; i++)
        {
            if (i != previousSceneIndex && backgroundAudioSources[i] != null)
            {
                backgroundAudioSources[i].Stop();
            }
        }
    }

    private void LoadVolumesFromPlayerPrefs()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        backgroundVolumeSlider.value = PlayerPrefs.GetFloat("BackgroundVolume", 1.0f);
        effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1.0f);
    }

    private void ApplyVolumes()
    {
        float masterVolume = masterVolumeSlider.value;
        float backgroundVolume = backgroundVolumeSlider.value;
        float effectVolume = effectVolumeSlider.value;

        for (int i = 0; i < backgroundAudioSources.Length; i++)
        {
            if (backgroundAudioSources[i] != null)
            {
                backgroundAudioSources[i].volume = masterVolume * backgroundVolume;
            }
        }

        for (int i = 0; i < effectAudioSources.Length; i++)
        {
            if (effectAudioSources[i] != null)
            {
                effectAudioSources[i].volume = masterVolume * effectVolume;
            }
        }
    }

    private void LoadAndPlaySceneBackground()
    {
        if (this == null) return;

        string sceneName = SceneManager.GetActiveScene().name;
        string backgroundMusicName = sceneName + "Background";

        AudioClip sceneBackground = Resources.Load<AudioClip>(backgroundMusicName);

        if (sceneBackground != null)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (sceneIndex < backgroundAudioSources.Length)
            {
                if (backgroundAudioSources[sceneIndex] != null)
                {
                    backgroundAudioSources[sceneIndex].clip = sceneBackground;
                    ApplyVolumes();
                    backgroundAudioSources[sceneIndex].loop = true;
                    backgroundAudioSources[sceneIndex].Play();
                }
                else
                {
                    if (this != null)
                    {
                        backgroundAudioSources[sceneIndex] = gameObject.AddComponent<AudioSource>();
                        backgroundAudioSources[sceneIndex].clip = sceneBackground;
                        ApplyVolumes();
                        backgroundAudioSources[sceneIndex].loop = true;
                        backgroundAudioSources[sceneIndex].Play();
                    }
                }
            }
        }
    }

    public void SetMasterVolume(float volume)
    {
        masterVolumeSlider.value = volume;
        ApplyVolumes();
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetBackgroundVolume(float volume)
    {
        backgroundVolumeSlider.value = volume;
        ApplyVolumes();
        PlayerPrefs.SetFloat("BackgroundVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetEffectVolume(float volume)
    {
        effectVolumeSlider.value = volume;
        ApplyVolumes();
        PlayerPrefs.SetFloat("EffectVolume", volume);
        PlayerPrefs.Save();
    }

    public void PlayItemSound(string itemName)
    {
        int audioSourceIndex = -1;
        AudioClip itemClip = null;

        switch (itemName)
        {
            case "Booster":
                audioSourceIndex = 0;
                itemClip = Resources.Load<AudioClip>("BoosterSound");
                break;
            case "Coffee":
                audioSourceIndex = 1;
                itemClip = Resources.Load<AudioClip>("CoffeeSound");
                break;
            case "Coin":
                audioSourceIndex = 2;
                itemClip = Resources.Load<AudioClip>("CoinSound");
                break;
            case "Pillow":
                audioSourceIndex = 3;
                itemClip = Resources.Load<AudioClip>("PillowSound");
                break;
            case "SmartPhone":
                audioSourceIndex = 4;
                itemClip = Resources.Load<AudioClip>("SmartPhoneSound");
                break;
            case "Soju":
                audioSourceIndex = 5;
                itemClip = Resources.Load<AudioClip>("SojuSound");
                break;
            case "SojuCleaner":
                audioSourceIndex = 6;
                itemClip = Resources.Load<AudioClip>("SojuCleanerSound");
                break;
            default:
                Debug.LogWarning("No sound for this item.");
                break;
        }

        if (itemClip != null)
        {
            if (audioSourceIndex >= 0 && audioSourceIndex < effectAudioSources.Length)
            {
                effectAudioSources[audioSourceIndex].clip = itemClip;
                ApplyVolumes();
                effectAudioSources[audioSourceIndex].Play();
            }
            else
            {
                Debug.LogWarning("Invalid audio source index");
            }
        }
    }
    
    public AudioClip backgroundMusic;

    private AudioSource backgroundAudioSource;

    private void Start()
    {
        backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundAudioSource.clip = backgroundMusic;
        backgroundAudioSource.loop = false; // 루프를 비활성화하여 한 번만 재생되도록 설정
        backgroundAudioSource.Play();
    }

    private void Update()
    {
        if (!backgroundAudioSource.isPlaying)
        {
            // 노래가 끝났을 때 다시 재생
            backgroundAudioSource.Play();
        }
    }
}



























































