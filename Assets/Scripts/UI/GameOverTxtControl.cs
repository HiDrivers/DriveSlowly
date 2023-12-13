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
                gameOverTxt.text = "빨리빨리에 집착하여, 과속 욕심을 부리는 운전자님. 도착지가 아닌 다른 곳에 빨리빨리 도착할지도 모릅니다.";
            }
            else
            {
                gameOverTxt.text = "한쪽에만 치우쳐 교통의 흐름을 파악하지 아니하고 주행하는 것은 자신과 타인의 생명을 모두 위협합니다.";
            }

        }
        else if (currentScene == "Stage2Scene")
        {
            if (gameManager.sleepMode)
            {
                gameOverTxt.text = "운전 중 카페인 섭취는 운전자님의 졸음운전을 잠시나마 방지해 줍니다.";
            }
            else if(gameManager.currentSmartPhoneCount > 0)
            {
                gameOverTxt.text = "운전 중 SNS와 알람 확인은 사고의 위험을 높일 수 있습니다.";
            }
            else if(gameManager.currentPillowCount > 0)
            {
                gameOverTxt.text = "베개는 운전이 끝나고 사용해도 늦지 않습니다.";
            }
            else
            {
                gameOverTxt.text = "잘못된 운전은 돌이킬 수 없는 결과를 초래할 수 있습니다.";
            }
        }
        else if (currentScene == "Stage3Scene")
        {
            if (gameManager.drunkMode)
            {
                gameOverTxt.text = "숙취해소제는 잠시 동안 술을 깨게 해주지만 모든 것을 해결해 주진 않습니다.";
            }
            else if (gameManager.currentSojuCount > 0)
            {
                gameOverTxt.text = "운전 중 음주는 법으로 엄격히 금지되어 있습니다.";
            }
            else
            {
                gameOverTxt.text = "잘못된 운전은 돌이킬 수 없는 결과를 초래할 수 있습니다.";
            }
        }
    }
}
