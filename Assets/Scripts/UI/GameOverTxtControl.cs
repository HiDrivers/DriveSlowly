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
            gameOverTxt.text = "빨리빨리에 집착하여, 과속 욕심을 부리는 운전자님. 도착지가 아닌 다른 곳에 빨리빨리 도착할지도 모릅니다.";
        }
        else if (currentScene == "Stage2Scene")
        {
            gameOverTxt.text = "운전 중 SNS와 알람 확인은 사고의 위험을 높일 수 있습니다.";
        }
        else if (currentScene == "Stage3Scene")
        {
            gameOverTxt.text = "숙취해소제는 잠시 동안 술을 깨게 해주지만 모든 것을 해결해 주진 않습니다.";
        }
    }
}
