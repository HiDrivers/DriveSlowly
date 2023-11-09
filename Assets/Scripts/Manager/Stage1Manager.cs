using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Manager : StageManager
{
    [SerializeField] private GameObject boosterPrefab;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
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
                Instantiate(boosterPrefab, spawnPoint.transform.GetChild(0).gameObject.transform.GetChild(index).gameObject.transform);
            }
            itemTimer = 0;
        }

        // 厘局拱 积己 包府
        if (obstacleTimer > obstacleSpawnCool)
        {
            ObstacleGenerateManager_Jin.Instance.CreateObstacle();
            obstacleTimer = 0;
            obstacleSpawnCool = Random.Range(2.0f, 4.0f);
        }
    }
}
