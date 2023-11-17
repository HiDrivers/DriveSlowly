using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject resumeButton;
    public GameObject settingButton;
    public GameObject lobbyButton;

    private UIManager uiManager;
    private SoundManager soundManager;
    private bool isPaused = false;

    void Start()
    {
        uiManager = UIManager.Instance;
        ResumeGame();
    }

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pausePanel.SetActive(true);
        resumeButton.SetActive(true);
        settingButton.SetActive(true);
        lobbyButton.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void ShowSettingUI()
    {
        Debug.Log("Displaying settings UI");
        CloseSettingUi settingUI = uiManager.ShowUI<CloseSettingUi>("SettingUi", transform);
        if (settingUI != null && soundManager != null)
        {
            settingUI.SetSoundManagerReference(soundManager);
            settingUI.ShowAndApplySavedValues();
        }
    }

    public void LoadLobby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LobbyScene");
    }

    public void OnSettingsClosed()
    {
        FindObjectOfType<CloseSettingUi>()?.LoadAndApplySliderValues();
        PlayerPrefs.Save();
    }
}



















