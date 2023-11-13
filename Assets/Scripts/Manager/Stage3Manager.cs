using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Manager : StageManager
{
    [SerializeField] private GameObject sojuPrefab;
    [SerializeField] private GameObject sojuCleanerPrefab;

    private bool isDrunk = false;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        PlayerDrunkUIControl();
        if(GameManager.Instance.drunkMode)
        {
            PlayerDrunkUIControl();
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
            int itemIdx = Random.Range(0, 2);
            if (itemIdx == 0)
            {
                Instantiate(coinPrefab, spawnPoint.transform.GetChild(0).gameObject.transform.GetChild(index).gameObject.transform);
            }
            else
            {
                if(GameManager.Instance.drunkMode)
                {
                    Instantiate(sojuCleanerPrefab, spawnPoint.transform.GetChild(0).gameObject.transform.GetChild(index).gameObject.transform);
                }
                else
                {
                    Instantiate(sojuPrefab, spawnPoint.transform.GetChild(0).gameObject.transform.GetChild(index).gameObject.transform);
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
        if (isDrunk != GameManager.Instance.isDrunk)
        {
            PlayerDrunkUIControl();
            isDrunk = GameManager.Instance.isDrunk;
        }
    }

    public void PlayerDrunkUIControl()
    {
        ControlUI.transform.GetChild(0).gameObject.SetActive(!GameManager.Instance.isDrunk);
        ControlUI.transform.GetChild(1).gameObject.SetActive(GameManager.Instance.isDrunk);
    }
}
