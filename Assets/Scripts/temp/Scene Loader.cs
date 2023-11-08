using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // ù ��° ��ư�� Ŭ���� �� �̵��� �� �̸�
    public string sceneName1 = "Select SceneA";

    // �� ��° ��ư�� Ŭ���� �� �̵��� �� �̸�
    public string sceneName2 = "Select SceneB";

    public string sceneName3 = "LobbyScene";

    public string sceneName4 = "MainScene";

    public string sceneName5 = "SettingScene";
    // ù ��° ��ư Ŭ�� �� ȣ��� �Լ�
    public void LoadScene1OnClick()
    {
        SceneManager.LoadScene(sceneName1);
    }

    // �� ��° ��ư Ŭ�� �� ȣ��� �Լ�
    public void LoadScene2OnClick()
    {
        SceneManager.LoadScene(sceneName2);
    }

    public void LoadScene3OnClick()
    {
        SceneManager.LoadScene(sceneName3);
    }

    public void LoadScene4OnClick()
    {
        SceneManager.LoadScene(sceneName4);
    }

    public void LoadScene5OnClick()
    {
        SceneManager.LoadScene(sceneName5);
    }
}


