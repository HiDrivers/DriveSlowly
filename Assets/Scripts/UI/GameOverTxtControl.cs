using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTxtControl : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text gameOverTxt;
    private string currentScene;
    void Start()
    {
        gameOverTxt = GetComponent<TMP_Text>();
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Stage1Scene")
        {
            gameOverTxt.text = "���������� �����Ͽ�, ���� ����� �θ��� �����ڴ�. �������� �ƴ� �ٸ� ���� �������� ���������� �𸨴ϴ�.";
        }
        else if (currentScene == "Stage2Scene")
        {
            gameOverTxt.text = "���� �� SNS�� �˶� Ȯ���� ����� ������ ���� �� �ֽ��ϴ�.";
        }
        else if (currentScene == "Stage3Scene")
        {
            gameOverTxt.text = "�����ؼ����� ��� ���� ���� ���� �������� ��� ���� �ذ��� ���� �ʽ��ϴ�.";
        }
    }
}
