using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Manager : StageManager
{
    [SerializeField] private GameObject smartPhonePrefab;
    [SerializeField] private GameObject coffeePrefab;
    [SerializeField] private GameObject pillowPrefab;

    [SerializeField] private GameObject sleepShade;

    private bool isSleep = false;
    private bool isPhone = false;

    public int currentArrow;

    protected override void Start()
    {
        base.Start();
        if (gameManager.sleepMode)
        {
            PlayerSleepUIControl();
        }
    }

    protected override void Update()
    {
        base.Update();
        // 酒捞袍 积己 包府
        if (itemTimer > itemSpawnCool)
        {
            int index = Random.Range(0, 4);
            int itemIdx = Random.Range(0, 10);
            if (itemIdx < 3)
            {
                Instantiate(coinPrefab, spawnPoint[index], Quaternion.identity);
            }
            else if (itemIdx < 5) 
            {
                Instantiate(smartPhonePrefab, spawnPoint[index], Quaternion.identity);
            }
            else
            {
                if (GameManager.Instance.sleepMode)
                {
                    Instantiate(coffeePrefab, spawnPoint[index], Quaternion.identity);
                }
                else
                {
                    Instantiate(pillowPrefab, spawnPoint[index], Quaternion.identity);
                }
            }
            itemTimer = 0;
        }

        // 厘局拱 积己 包府
        if (obstacleTimer > obstacleSpawnCool)
        {
            obstacleManager.GetComponent<ObstacleGenerateManager>().CreateObstacle(multiplier);
            obstacleTimer = 0;
            if (currentTime < 30)
            {
                obstacleSpawnCool = Random.Range(2.0f, 4.0f);
            }
            else if (currentTime < 60)
            {
                obstacleSpawnCool = Random.Range(2.0f, 3.1f);
                multiplier = 1.1f;
            }
            else if (currentTime < 90)
            {
                obstacleSpawnCool = 1.8f;
                multiplier = 1.2f;
            }
            else
            {
                obstacleSpawnCool = 1.6f;
            }
        }
        if (isSleep != gameManager.isSleep)
        {
            PlayerSleepUIControl();
            isSleep = gameManager.isSleep;
        }
        if (isPhone != gameManager.isPhone)
        {
            PlayerPhoneUIControl();
            isPhone = gameManager.isPhone;
        }
    }

    public void PlayerSleepUIControl()
    {
        sleepShade.SetActive(gameManager.isSleep);
    }

    public void PlayerPhoneUIControl()
    {
        if (GameManager.Instance.isPhone)
        {
            currentArrow = Random.Range(0, 4);
            ControlUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(currentArrow).gameObject.SetActive(false);
            GameManager.Instance.currentArrow = currentArrow;
        }
        else
        {
            ControlUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(currentArrow).gameObject.SetActive(true);
        }
    }
}
