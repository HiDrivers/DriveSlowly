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
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        if (GameManager.Instance.sleepMode)
        {
            PlayerSleepUIControl();
        }
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        // 酒捞袍 积己 包府
        if (itemTimer > itemSpawnCool)
        {
            int index = Random.Range(0, 4);
            int itemIdx = Random.Range(0, 4);
            if (itemIdx == 0)
            {
                Instantiate(coinPrefab, spawnPoint.transform.GetChild(0).gameObject.transform.GetChild(index).gameObject.transform);
            }
            else if (itemIdx == 1) 
            {
                Instantiate(smartPhonePrefab, spawnPoint.transform.GetChild(0).gameObject.transform.GetChild(index).gameObject.transform);
            }
            else
            {
                if (GameManager.Instance.sleepMode)
                {
                    Instantiate(coffeePrefab, spawnPoint.transform.GetChild(0).gameObject.transform.GetChild(index).gameObject.transform);
                }
                else
                {
                    Instantiate(pillowPrefab, spawnPoint.transform.GetChild(0).gameObject.transform.GetChild(index).gameObject.transform);
                }
            }
            itemTimer = 0;
        }

        // 厘局拱 积己 包府
        if (obstacleTimer > obstacleSpawnCool)
        {
            ObstacleManager.GetComponent<ObstacleGenerateManager_Jin>().CreateObstacle();
            obstacleTimer = 0;
            obstacleSpawnCool = Random.Range(2.0f, 4.0f);
        }
        if (isSleep != GameManager.Instance.isSleep)
        {
            PlayerSleepUIControl();
            isSleep = GameManager.Instance.isSleep;
        }
        if (isPhone != GameManager.Instance.isPhone)
        {
            PlayerPhoneUIControl();
            isPhone = GameManager.Instance.isPhone;
        }
    }

    public void PlayerSleepUIControl()
    {
        sleepShade.SetActive(GameManager.Instance.isSleep);
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
