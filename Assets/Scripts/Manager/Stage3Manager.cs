using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Manager : StageManager
{
    [SerializeField] private GameObject sojuPrefab;
    [SerializeField] private GameObject sojuCleanerPrefab;

    private bool isDrunk = false;
    private int currentControl;
    private float drunkControlTimer = 5;

    protected override void Start()
    {
        base.Start();
        currentControl = Random.Range(1, 4);
        PlayerDrunkUIControl();
    }

    protected override void Update()
    {
        base.Update();
        // 아이템 생성 관리
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

        // 장애물 생성 관리
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
                multiplier = 1.3f;
            }
        }
        if (isDrunk != gameManager.isDrunk)
        {
            PlayerDrunkUIControl();
            isDrunk = gameManager.isDrunk;
        }

        if (isDrunk && drunkControlTimer < currentTime)
        {
            ControlUI.transform.GetChild(currentControl).gameObject.SetActive(false);
            player.GetComponent<PlayerControl>().AllUp();
            currentControl = ((Random.Range(0, 2) + currentControl) % 3) + 1; // 이전 방향키와 겹치지 않게
            ControlUI.transform.GetChild(currentControl).gameObject.SetActive(true);
            drunkControlTimer = currentTime + 5;
        }
    }

    public void PlayerDrunkUIControl()
    {
        ControlUI.transform.GetChild(0).gameObject.SetActive(!gameManager.isDrunk);
        ControlUI.transform.GetChild(currentControl).gameObject.SetActive(gameManager.isDrunk);
    }
}
