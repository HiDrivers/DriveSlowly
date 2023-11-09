using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 첫 번째 버튼이 클릭될 때 이동할 씬 이름
    public string sceneName1 = "LobbyScene";

    public string sceneName2 = "MapTestScene";

    public string sceneName3 = "EndingScene";

    // 첫 번째 버튼 클릭 시 호출될 함수
    public void LoadScene1OnClick()
    {
        SceneManager.LoadScene(sceneName1);
    }

    // 두 번째 버튼 클릭 시 호출될 함수
    public void LoadScene2OnClick()
    {
        SceneManager.LoadScene(sceneName2);
    }

    public void LoadScene3OnClick()
    {
        SceneManager.LoadScene(sceneName3);
    }
}

    

