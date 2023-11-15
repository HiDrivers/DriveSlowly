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
}

    

