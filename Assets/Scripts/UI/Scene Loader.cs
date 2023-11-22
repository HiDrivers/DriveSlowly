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

    public void GameSceneReload()
    {
        // ÇöÀç ¾ÀÀ» ´Ù½Ã ºÒ·¯¿È
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}





