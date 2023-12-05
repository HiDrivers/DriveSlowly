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
        SceneManager.LoadScene("LobbyScene");
    }

    public void CutScene2_0Load()
    {
        SceneManager.LoadScene("CutScene2_0");
    }

    public void CutScene2_1Load()
    {
        SceneManager.LoadScene("CutScene2_1");
    }

    public void CutScene2_2Load()
    {
        SceneManager.LoadScene("CutScene2_2");
    }

    public void CutScene3_1Load()
    {
        SceneManager.LoadScene("CutScene3_1");
    }

    public void CutScene3_2Load()
    {
        SceneManager.LoadScene("CutScene3_2");
    }

    public void GameSceneReload()
    {
        // ÇöÀç ¾ÀÀ» ´Ù½Ã ºÒ·¯¿È
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}





