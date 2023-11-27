using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // 현재 스테이지 관리
    public string currentStage;

    private Transform UIRoot;

    // 엔딩 관리
    public int currentGoldCount = 0;
    public int totalItemCount = 0;
    public int currentBoosterCount = 0;
    public int currentCoffeeCount = 0;
    public int currentPillowCount = 0;
    public int currentSmartPhoneCount = 0;
    public int currentSojuCount = 0;
    public int currentSojuCleanerCount = 0;
    public float totalDurabilityDamage = 0;
            
    // 돈 관리
    public int gold = 0;

    // 난폭운전 관리 (1스테이지)
    [Header("Stage 1 Reckless Drive")]
    public bool isBoost = false;
    public float boostTimer = 0;


    // 졸음운전 관리(2스테이지)
    [Header("Stage 2 Sleepy Drive")]
    public bool sleepMode = false;
    public bool isSleep = false;
    public float sleepTimer = 0;

    // 스마트폰 관리
    public bool isPhone = false;
    public float phoneTimer = 0;
    public int currentArrow;

    // 음주운전 관리(3스테이지)
    [Header ("Stage 3 Drunk drive")]
    public bool drunkMode = false;
    public bool isDrunk = false;
    public float drunkTimer = 0;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("IsFirst"))
        {
            PlayerPrefs.SetInt("IsFirst", 0);
        }
    }


    public void InGameStart()
    {
        if (drunkMode)
        {
            isDrunk = true;

        }
        if (sleepMode)
        {
            isSleep = true;
        }
    }

    void Update()
    {
        // 난폭운전 부분 컨트롤
        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer < 0)
            {
                boostTimer = 0;
                isBoost = false;
            }
        }
        // 졸음운전 부분 컨트롤
        if (sleepTimer > 0)
        {
            sleepTimer -= Time.deltaTime;
            if (sleepTimer < 0)
            {
                sleepTimer = 0;
                if (sleepMode) isSleep = true;
                else isSleep = false;
            }
        }
        // 음주 부분 컨트롤
        if (drunkTimer > 0)
        {
            drunkTimer -= Time.deltaTime;
            if (drunkTimer < 0)
            {
                drunkTimer = 0;
                if (drunkMode) isDrunk = true;
                else isDrunk = false;
            }
        }
        // 스마트폰 부분 컨트롤
        if (phoneTimer > 0)
        {
            phoneTimer -= Time.deltaTime;
            if (phoneTimer < 0)
            {
                phoneTimer = 0;
                isPhone = false;
            }
        }
    }

    public void LoadNextScene()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "LobbyScene":
                SceneManager.LoadScene("CutScene1");
                break;
            case "CutScene1":
                SceneManager.LoadScene("Stage1Scene");
                InGameStart();
                break;
            case "Stage1Scene":
                SceneManager.LoadScene("CutScene2_0");
                break;
            case "CutScene2_0":
                if (PlayerPrefs.GetInt("IsFirst") == 0)
                {
                    sleepMode = true;
                    SceneManager.LoadScene("CutScene2_1");
                }
                else
                {
                    sleepMode = false;
                    UIRoot = GameObject.Find("UIRoot").transform;
                    UIManager.Instance.ShowUI<UIBase>("SelectUI1", UIRoot);
                }
                break;
            case "CutScene2_1":
                SceneManager.LoadScene("Stage2Scene");
                InGameStart();
                break;
            case "CutScene2_2":
                SceneManager.LoadScene("Stage2Scene");
                drunkMode = true;
                break;
            case "Stage2Scene":
                SceneManager.LoadScene("CutScene3_0");
                break;
            case "CutScene3_0":
                if (PlayerPrefs.GetInt("IsFirst") == 0)
                {
                    drunkMode = true;
                    SceneManager.LoadScene("CutScene3_1");
                }
                else
                {
                    drunkMode = false;
                    UIRoot = GameObject.Find("UIRoot").transform;
                    UIManager.Instance.ShowUI<UIBase>("SelectUI2", UIRoot);
                }
                break;
            case "CutScene3_1":
                drunkMode = true;
                SceneManager.LoadScene("Stage3Scene");
                InGameStart();
                break;
            case "CutScene3_2":
                drunkMode = false;
                SceneManager.LoadScene("Stage3Scene");
                InGameStart();
                break;

            case "Stage3Scene":
                PlayerPrefs.SetInt("IsFirst", 1);
                Debug.Log("EndingScene Activated");
                SceneManager.LoadScene("EndingScene");
                break;

        }
    }

    public void CheckEnding()
    {
        // 배드 엔딩1
        // 배드 드라이버 엔딩
        if (drunkMode && sleepMode && currentBoosterCount > 0 && totalDurabilityDamage == 0)
        {
            // EndingManager.Instance.endingPanels[0].blindObject.SetActive(false); CheckEnding이 작동함에 따라 엔딩이 해금될 겁니다.
        }
        // 악질 엔딩
        else if (drunkMode && sleepMode && currentBoosterCount > 0)
        {

        }
        // 졸음 운전 엔딩
        else if(sleepMode && !drunkMode && currentBoosterCount == 0)
        {

        }
        // 음주 운전 엔딩
        else if(!sleepMode && drunkMode && currentBoosterCount == 0)
        {

        }
        // 난폭운전 엔딩
        else if(!drunkMode && !drunkMode && currentBoosterCount > 0)
        {

        }
        // 배드 엔딩2
        else if (!drunkMode && !drunkMode && currentBoosterCount == 0)
        {
            // 바보 엔딩
            if (currentSojuCount > 0 && currentPillowCount > 0 && currentSmartPhoneCount > 0)
            {

            }

            // 스마트폰 엔딩
            else if (currentSmartPhoneCount > 0 && currentSojuCount == 0 && currentPillowCount == 0)
            {

            }
            // 스페셜 엔딩
            else if (totalItemCount == 0)
            {
                // 헤지 펀드
                if (currentGoldCount > 200)
                {

                }
                // 진엔딩 초입
                else
                {

                }
            }
        }
    }

}
