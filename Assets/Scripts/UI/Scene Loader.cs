using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GameSceneLoad()
    {
        GameManager.Instance.LoadNextScene();
    }

    public void LobbyLoad()
    {
        PlayerData.Instance.gold -= GameManager.Instance.totalGoldCount;
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
        // ���� ���� �ٽ� �ҷ���
        GameManager.Instance.totalGoldCount -= GameManager.Instance.currentStageGoldCount;
        GameManager.Instance.InGameStart();
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






