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
        ResumeGame(); // 시작 시 게임은 실행 중으로 설정
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
        // Debug.Log를 이용하여 호출되는 부분 확인
        Debug.Log("Trying to show Setting UI");
        uiManager.ShowUI<SettingUI>("SettingUi", transform);
    }

    public void LoadLobby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LobbyScene");
    }
}





















































