using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void SceneLoad()
    {
        GameManager.Instance.LoadNextScene();
    }
}

    

