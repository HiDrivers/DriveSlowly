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
        // ���� ���� �ٽ� �ҷ���
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}





