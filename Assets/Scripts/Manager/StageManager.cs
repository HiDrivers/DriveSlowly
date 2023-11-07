using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : Singleton<StageManager>
{
    public GameObject spawnPoint;

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject boosterPrefab;

    public float clearTime = 120;
    public float currentTime;

    public float maxHp;
    public float curHp;

    private float itemTimer = 0;
    private float obstacleTimer = 0;

    [SerializeField] private float itemSpawnCool;
    private float obstacleSpawnCool = 0;

    public Slider progress;
    public Slider durability;
    public TMP_Text gold;

    private void Start()
    {
        currentTime = 0;
        gold.text = $"{GameManager.Instance.gold} G";
        curHp = maxHp;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        itemTimer += Time.deltaTime;
        obstacleTimer += Time.deltaTime;

        if (GameManager.Instance.isBoost)
        {
            currentTime += Time.deltaTime * 2;
        }

        progress.value = (float) currentTime / clearTime;
        durability.value = curHp / maxHp;
        gold.text = $"{GameManager.Instance.gold} G";
        Stage1();

    }

    public void Stage1()
    {
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
