using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Manager : StageManager
{
    [SerializeField] private GameObject boosterPrefab;

    protected override void Start()
    {
        base.Start();
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
                Instantiate(boosterPrefab, spawnPoint[index], Quaternion.identity);
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
    }
}
