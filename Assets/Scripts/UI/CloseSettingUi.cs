using UnityEngine;
using UnityEngine.UI;

public class CloseSettingUi : UIBase
{
    public GameObject settingPanel;
    public Button closeButton;

    private SoundManager soundManager;

    public Slider masterVolumeSlider;
    public Slider backgroundVolumeSlider;
    public Slider effectVolumeSlider;

    private void Start()
    {
        settingPanel = gameObject;
        soundManager = FindObjectOfType<SoundManager>();

        LoadAndApplySliderValues();

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(SaveAndHide);
        }
    }

    public void SaveSliderValues()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("BackgroundVolume", backgroundVolumeSlider.value);
        PlayerPrefs.SetFloat("EffectVolume", effectVolumeSlider.value);
        PlayerPrefs.Save();
    }

    public void LoadAndApplySliderValues()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        backgroundVolumeSlider.value = PlayerPrefs.GetFloat("BackgroundVolume", 1.0f);
        effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1.0f);

        ApplyLoadedValues();
    }

    private void ApplyLoadedValues()
    {
        if (soundManager != null)
        {
            soundManager.SetMasterVolume(masterVolumeSlider.value);
            soundManager.SetBackgroundVolume(backgroundVolumeSlider.value);
            soundManager.SetEffectVolume(effectVolumeSlider.value);
        }
    }

    public void SaveAndHide()
    {
        if (settingPanel != null)
        {
            SaveSliderValues();
            settingPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Setting panel not assigned!");
        }
    }

    public void ShowAndApplySavedValues()
    {
        LoadAndApplySliderValues();
        settingPanel.SetActive(true);
        ApplyLoadedValues();
    }

    public void SetSoundManagerReference(SoundManager manager)
    {
        soundManager = manager;
    }
}
















































