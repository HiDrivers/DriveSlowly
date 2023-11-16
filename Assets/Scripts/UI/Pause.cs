using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject resumeButton;
    public GameObject settingButton;
    public GameObject lobbyButton;

    private UIManager uiManager;
    private bool isPaused = false;

    void Start()
    {
        uiManager = UIManager.Instance;
        ResumeGame(); // ���� �� ������ ���� ������ ����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
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
        // Debug.Log�� �̿��Ͽ� ȣ��Ǵ� �κ� Ȯ��
        Debug.Log("Trying to show Setting UI");
        uiManager.ShowUI<SettingUI>("SettingUi", transform);
    }

    public void LoadLobby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LobbyScene");
    }
}





















































