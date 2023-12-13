using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void GameSceneLoad()
    {
        gameManager.LoadNextScene();
    }

    public void StartLoad()
    {
        SceneManager.LoadScene("StartScene");
        SetTimeScaleToNormal();
    }

    public void LobbyLoad()
    {
        PlayerData.Instance.gold -= gameManager.totalGoldCount;
        SceneManager.LoadScene("LobbyScene");
        SetTimeScaleToNormal();
    }

    public void CutScene2_0Load()
    {
        SceneManager.LoadScene("CutScene2_0");
        SetTimeScaleToNormal();
    }

    public void CutScene2_1Load()
    {
        SceneManager.LoadScene("CutScene2_1");
        SetTimeScaleToNormal();
    }

    public void CutScene2_2Load()
    {
        SceneManager.LoadScene("CutScene2_2");
        SetTimeScaleToNormal();
    }

    public void CutScene3_0Load()
    {
        SceneManager.LoadScene("CutScene3_0");
        SetTimeScaleToNormal();
    }

    public void CutScene3_1Load()
    {
        SceneManager.LoadScene("CutScene3_1");
        SetTimeScaleToNormal();
    }

    public void CutScene3_2Load()
    {
        SceneManager.LoadScene("CutScene3_2");
        SetTimeScaleToNormal();
    }

    public void GameSceneReload()
    {
        // ÇöÀç ¾ÀÀ» ´Ù½Ã ºÒ·¯¿È
        gameManager.totalGoldCount -= gameManager.currentStageGoldCount;
        PlayerData.Instance.gold -= gameManager.currentStageGoldCount;
        gameManager.InGameStart();
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        SetTimeScaleToNormal();
    }

    private void SetTimeScaleToNormal()
    {
        Time.timeScale = 1f;
        Screen.SetResolution(1080, 1920, false);
    }
}






