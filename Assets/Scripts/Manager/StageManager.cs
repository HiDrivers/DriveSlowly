using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject spawnPoint;

    [SerializeField] protected GameObject coinPrefab;
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject ControlUI;

    public float clearTime = 120;
    public float currentTime;

    protected float itemTimer = 0;
    protected float obstacleTimer = 0;

    [SerializeField] protected float itemSpawnCool;
    protected float obstacleSpawnCool = 0;

    public Slider progress;
    public Slider durability;
    public TMP_Text gold;

    protected bool gameClear = false;

    protected void Start()
    {
        currentTime = 0;
        gold.text = $"{GameManager.Instance.gold} G";
    }

    protected void Update()
    {
        if (!gameClear)
        {
            currentTime += Time.deltaTime;
            itemTimer += Time.deltaTime;
            obstacleTimer += Time.deltaTime;

            if (GameManager.Instance.isBoost)
            {
                currentTime += Time.deltaTime * 2;
            }

            progress.value = (float) currentTime / clearTime;
            durability.value = player.GetComponent<HealthSystem>().curHp / player.GetComponent<HealthSystem>().maxHp;
            gold.text = $"{GameManager.Instance.gold} G";
            if (currentTime >= clearTime)
            {
                gameClear = true;
            }
        }
    }
}
