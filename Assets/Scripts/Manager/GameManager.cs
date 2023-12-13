using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // ���� �������� ����
    public string currentStage;

    private Transform UIRoot;

    // ���� ����
    public int totalGoldCount = 0;
    public int totalItemCount = 0;
    public int currentBoosterCount = 0;
    public int currentCoffeeCount = 0;
    public int currentPillowCount = 0;
    public int currentSmartPhoneCount = 0;
    public int currentSojuCount = 0;
    public int currentSojuCleanerCount = 0;
    public float totalDurabilityDamage = 0;
    public int currentStageGoldCount = 0;

    public int endingSceneNum = 1;
            
    // �������� ���� (1��������)
    [Header("Stage 1 Reckless Drive")]
    public bool isBoost = false;
    public float boostTimer = 0;


    // �������� ����(2��������)
    [Header("Stage 2 Sleepy Drive")]
    public bool sleepMode = false;
    public bool isSleep = false;
    public float sleepTimer = 0;

    // ����Ʈ�� ����
    public bool isPhone = false;
    public float phoneTimer = 0;
    public int currentArrow;

    // ���ֿ��� ����(3��������)
    [Header ("Stage 3 Drunk drive")]
    public bool drunkMode = false;
    public bool isDrunk = false;
    public float drunkTimer = 0;
    
    public void Start()
    {
        if (!PlayerPrefs.HasKey("IsFirst"))
        {
            PlayerPrefs.SetInt("IsFirst", 0);
        }
        PlayerPrefs.SetInt("CarSlot0", 1);
    }

    private void DataInitialize()
    {
        totalGoldCount = 0;
        totalItemCount = 0;
        currentBoosterCount = 0;
        currentCoffeeCount = 0;
        currentPillowCount = 0;
        currentSmartPhoneCount = 0;
        currentSojuCount = 0;
        currentSojuCleanerCount = 0;
        totalDurabilityDamage = 0;
        currentStageGoldCount = 0;

        sleepMode = false;
        drunkMode = false;
        isBoost = false;
        isPhone = false;
    }


    public void InGameStart()
    {
        isDrunk = drunkMode;
        isSleep = sleepMode;
        isBoost = false;
        currentStageGoldCount = 0;
    }

    void Update()
    {
        // �������� �κ� ��Ʈ��
        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer < 0)
            {
                boostTimer = 0;
                isBoost = false;
            }
        }
        // �������� �κ� ��Ʈ��
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
        // ���� �κ� ��Ʈ��
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
        // ����Ʈ�� �κ� ��Ʈ��
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
                DataInitialize();
                SceneManager.LoadScene("CutScene1");
                break;
            case "CutScene1":
                SceneManager.LoadScene("Stage1Scene");
                InGameStart();
                break;
            case "Stage1Scene":
                SceneManager.LoadScene("CutScene1_2");
                break;
            case "CutScene1_2":
                UIRoot = GameObject.Find("UIRoot").transform;
                UIManager.Instance.ShowUI<UIBase>("Stage1ClearUI", UIRoot);
                break;
            case "CutScene2_0":
                if (PlayerPrefs.GetInt("IsFirst") == 0)
                {
                    SceneManager.LoadScene("CutScene2_1");
                }
                else
                {
                    UIRoot = GameObject.Find("UIRoot").transform;
                    UIManager.Instance.ShowUI<UIBase>("SelectUI1", UIRoot);
                }
                break;
            case "CutScene2_1":
                sleepMode = true;
                SceneManager.LoadScene("Stage2Scene");
                InGameStart();
                break;
            case "CutScene2_2":
                sleepMode = false;
                SceneManager.LoadScene("Stage2Scene");
                break;
            case "Stage2Scene":
                SceneManager.LoadScene("CutScene2_3");
                break;
            case "CutScene2_3":
                UIRoot = GameObject.Find("UIRoot").transform;
                UIManager.Instance.ShowUI<UIBase>("Stage2ClearUI", UIRoot);
                break;
            case "CutScene3_0":
                if (PlayerPrefs.GetInt("IsFirst") == 0)
                {
                    SceneManager.LoadScene("CutScene3_1");
                }
                else
                {
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
                CheckEnding();
                PlayerPrefs.SetInt($"Ending{endingSceneNum}", 1);
                SceneManager.LoadScene("EndingScene0");
                break;
            case "EndingScene0":
                if (endingSceneNum < 5)
                {
                    SceneManager.LoadScene("EndingScene1");
                    break;
                }
                else
                {
                    SceneManager.LoadScene("EndingScene2");
                    break;
                }
            case "EndingScene1":
                PlayerData.Instance.goldDataSave();
                UIRoot = GameObject.Find("UIRoot").transform;
                UIManager.Instance.ShowUI<UIBase>("GameEndUI", UIRoot);
                break;
            case "EndingScene2":
                PlayerData.Instance.goldDataSave();
                UIRoot = GameObject.Find("UIRoot").transform;
                UIManager.Instance.ShowUI<UIBase>("GameEndUI", UIRoot);
                break;
        }
        Screen.SetResolution(1080, 1920, false);
    }

    public void CheckEnding()
    {
        // ��� ����1
        // ��� ����̹� ����
        if (drunkMode && sleepMode && currentBoosterCount > 0 && totalDurabilityDamage == 0) // ���ֿ��� + �������� + �������� + ������ 0
        {
            endingSceneNum = 5;
        }
        // ���� ����
        else if (drunkMode && sleepMode && currentBoosterCount > 0)  // ���ֿ��� + �������� + ��������
        {
            endingSceneNum = 1;
        }
        // ���� ������ ����
        else if (!drunkMode && !sleepMode) // ������ ��� �ǰ� ����
        {
            // ����Ʈ�� ���� : �ٸ� ������ ��� ���ϰ� ����Ʈ���� ����
            if (currentSmartPhoneCount > 0 && currentSojuCount == 0 && currentPillowCount == 0)
            {
                endingSceneNum = 7;
            }
            // ����� ����
            else if (totalItemCount == 0)
            {
                endingSceneNum = 9;
            }
            // �ٺ� ���� : ���� + ���� + ����Ʈ�� + �ν��� (������ ������ ��� ����)
            else if (currentSojuCount > 0 && currentPillowCount > 0 && currentSmartPhoneCount > 0 && currentBoosterCount > 0)
            {
                endingSceneNum = 6;
            }
            // �������� ����
            else if (currentBoosterCount > 0 && currentPillowCount == 0 && currentSmartPhoneCount == 0 && currentSojuCount == 0) // ���������� ����
            {
                endingSceneNum = 4;
            }
            else
            {
                endingSceneNum = 10; // ������ �Ϻ� ����
            }
        }
        // �����ݵ� ����
        else if (totalGoldCount >= 200)
        {
            endingSceneNum = 8;
            PlayerData.Instance.gold -= 200;
            totalGoldCount -= 200;
        }
        // ���� ���� ����
        else if(sleepMode && !drunkMode) // ���������� ����
        {
            endingSceneNum = 2;
        }
        // ���� ���� ����
        else if(!sleepMode && drunkMode) // ���ֿ����� ����
        {
            endingSceneNum = 3;
        }
        // ������ ���� (2���� �߸��� ����) ex) ���� + ���� or ���� + ���� or ���� + ����
        else
        {
            endingSceneNum = 1; // endingSceneNum = 10;
        }
    }

}
