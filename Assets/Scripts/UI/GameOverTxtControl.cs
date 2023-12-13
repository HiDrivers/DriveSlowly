using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTxtControl : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text gameOverTxt;
    private string currentScene;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
        gameOverTxt = GetComponent<TMP_Text>();
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Stage1Scene")
        {
            if (gameManager.currentBoosterCount > 0)
            {
                gameOverTxt.text = "���������� �����Ͽ�, ���� ����� �θ��� �����ڴ�. �������� �ƴ� �ٸ� ���� �������� ���������� �𸨴ϴ�.";
            }
            else
            {
                gameOverTxt.text = "���ʿ��� ġ���� ������ �帧�� �ľ����� �ƴ��ϰ� �����ϴ� ���� �ڽŰ� Ÿ���� ������ ��� �����մϴ�.";
            }

        }
        else if (currentScene == "Stage2Scene")
        {
            if (gameManager.sleepMode)
            {
                gameOverTxt.text = "���� �� ī���� ����� �����ڴ��� ���������� ��ó��� ������ �ݴϴ�.";
            }
            else if(gameManager.currentSmartPhoneCount > 0)
            {
                gameOverTxt.text = "���� �� SNS�� �˶� Ȯ���� ����� ������ ���� �� �ֽ��ϴ�.";
            }
            else if(gameManager.currentPillowCount > 0)
            {
                gameOverTxt.text = "������ ������ ������ ����ص� ���� �ʽ��ϴ�.";
            }
            else
            {
                gameOverTxt.text = "�߸��� ������ ����ų �� ���� ����� �ʷ��� �� �ֽ��ϴ�.";
            }
        }
        else if (currentScene == "Stage3Scene")
        {
            if (gameManager.drunkMode)
            {
                gameOverTxt.text = "�����ؼ����� ��� ���� ���� ���� �������� ��� ���� �ذ��� ���� �ʽ��ϴ�.";
            }
            else if (gameManager.currentSojuCount > 0)
            {
                gameOverTxt.text = "���� �� ���ִ� ������ ������ �����Ǿ� �ֽ��ϴ�.";
            }
            else
            {
                gameOverTxt.text = "�߸��� ������ ����ų �� ���� ����� �ʷ��� �� �ֽ��ϴ�.";
            }
        }
    }
}
