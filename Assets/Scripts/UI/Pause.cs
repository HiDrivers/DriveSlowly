using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject resumeButton;
    public GameObject settingButton;
    public GameObject lobbyButton;

    private bool isPaused = false;
    private float lastClickTime = 0f;
    private float clickDelay = 0.5f;

    public void TogglePause()
    {
        if (Time.time - lastClickTime < clickDelay) return;

        if (!isPaused)
            PauseGame();
        else
            ResumeGame();

        lastClickTime = Time.time;
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
}





























