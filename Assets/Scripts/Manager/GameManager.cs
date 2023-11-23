using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // ���� �������� ����
    public int currentStage = 0;

    // ���� ����
    public int currentGoldCount = 0;
    public int totalItemCount = 0;
    public int currentBoosterCount = 0;
    public int currentCoffeeCount = 0;
    public int currentPillowCount = 0;
    public int currentSmartPhoneCount = 0;
    public int currentSojuCount = 0;
    public int currentSojuCleanerCount = 0;
    public float totalDurabilityDamage = 0;
            
    // �� ����
    public int gold = 0;

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
        switch(currentStage)
        {
            case 0:
                SceneManager.LoadScene("CutScene1");
                currentStage += 1;
                break;
            case 1:
                SceneManager.LoadScene("Stage1Scene");
                currentStage += 1;
                InGameStart();
                break;
            case 2:
                SceneManager.LoadScene("CutScene2_0");
                currentStage += 1;
                break;
            case 3:
                SceneManager.LoadScene("CutScene2_1");
                GameManager.Instance.sleepMode = true;
                currentStage += 1;
                break;
            case 4:
                SceneManager.LoadScene("Stage2Scene");
                currentStage += 1;
                InGameStart();
                break;
            case 5:
                SceneManager.LoadScene("CutScene3_0");
                currentStage += 1;
                break;
            case 6:
                SceneManager.LoadScene("Stage3Scene");
                currentStage += 1;
                break;

        }
    }

    public void CheckEnding()
    {
        // ��� ����1
        // ��� ����̹� ����
        if (drunkMode && sleepMode && currentBoosterCount > 0 && totalDurabilityDamage == 0)
        {
            // EndingManager.Instance.endingPanels[0].blindObject.SetActive(false); CheckEnding�� �۵��Կ� ���� ������ �رݵ� �̴ϴ�.
        }
        // ���� ����
        else if (drunkMode && sleepMode && currentBoosterCount > 0)
        {

        }
        // ���� ���� ����
        else if(sleepMode && !drunkMode && currentBoosterCount == 0)
        {

        }
        // ���� ���� ����
        else if(!sleepMode && drunkMode && currentBoosterCount == 0)
        {

        }
        // �������� ����
        else if(!drunkMode && !drunkMode && currentBoosterCount > 0)
        {

        }
        // ��� ����2
        else if (!drunkMode && !drunkMode && currentBoosterCount == 0)
        {
            // �ٺ� ����
            if (currentSojuCount > 0 && currentPillowCount > 0 && currentSmartPhoneCount > 0)
            {

            }

            // ����Ʈ�� ����
            else if (currentSmartPhoneCount > 0 && currentSojuCount == 0 && currentPillowCount == 0)
            {

            }
            // ����� ����
            else if (totalItemCount == 0)
            {
                // ���� �ݵ�
                if (currentGoldCount > 200)
                {

                }
                // ������ ����
                else
                {

                }
            }
        }
    }

}
