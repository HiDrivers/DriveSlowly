using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Manager : StageManager
{
    [SerializeField] private GameObject sojuPrefab;
    [SerializeField] private GameObject sojuCleanerPrefab;

    private bool isDrunk = false;

    protected override void Start()
    {
        base.Start();
        PlayerDrunkUIControl();
        if(gameManager.drunkMode)
        {
            PlayerDrunkUIControl();
        }
    }

    protected override void Update()
    {
        base.Update();
        // 酒捞袍 积己 包府
        if (itemTimer > itemSpawnCool)
        {
            int index = Random.Range(0, 4);
            int itemIdx = Random.Range(0, 2);
            if (itemIdx == 0)
            {
                Instantiate(coinPrefab, spawnPoint[index], Quaternion.identity);
            }
            else
            {
                if(gameManager.drunkMode)
                {
                    Instantiate(sojuCleanerPrefab, spawnPoint[index], Quaternion.identity);
                }
                else
                {
                    Instantiate(sojuPrefab, spawnPoint[index], Quaternion.identity);
                }

            }
            itemTimer = 0;
        }

        // 厘局拱 积己 包府
        if (obstacleTimer > obstacleSpawnCool)
        {
            obstacleManager.GetComponent<ObstacleGenerateManager>().CreateObstacle();
            obstacleTimer = 0;
            obstacleSpawnCool = Random.Range(2.0f, 4.0f);
        }
        if (isDrunk != gameManager.isDrunk)
        {
            PlayerDrunkUIControl();
            isDrunk = gameManager.isDrunk;
        }
    }

    public void PlayerDrunkUIControl()
    {
        ControlUI.transform.GetChild(0).gameObject.SetActive(!gameManager.isDrunk);
        ControlUI.transform.GetChild(1).gameObject.SetActive(gameManager.isDrunk);
    }
}
