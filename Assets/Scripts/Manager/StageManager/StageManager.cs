using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Transform UIRoot;

    [SerializeField] protected GameObject obstacleManager;
    protected Vector3[] spawnPoint;

    [SerializeField] protected GameObject coinPrefab;
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject ControlUI;
    [SerializeField] private Image progressHandle;

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
    private bool isClearOn = false;
    private float gameStartDelay = 1;
    private bool gameOver = false;

    protected float multiplier = 1.0f;

    protected GameManager gameManager;
    private PlayerData playerData;
    HealthSystem healthSystem;

    [SerializeField] private GameObject damageIndicator;

    protected virtual void Awake()
    {
        gameManager = GameManager.Instance;
        playerData = PlayerData.Instance;
        healthSystem = player.GetComponent<HealthSystem>();
        spawnPoint = obstacleManager.GetComponent<ObstacleGenerateManager>().obstacleGenPositions;
    }

    protected virtual void Start()
    {
        currentTime = 0;
        damageIndicator.SetActive(true);
        UpdateGoldData();
        progressHandle.sprite = playerData.progressHandleImage;
    }

    protected virtual void Update()
    {
        if (gameOver)
        {
            return;
        }
        else if (healthSystem.curHp <= 0)
        {
            UIManager.Instance.ShowUI<UIBase>("GameOverUi", UIRoot);
            isClearOn = true;
            damageIndicator.SetActive(false);
            gameOver = true;
        }
        else if (!gameClear && gameStartDelay < 0)
        {
            currentTime += Time.deltaTime;
            itemTimer += Time.deltaTime;
            obstacleTimer += Time.deltaTime;

            if (gameManager.isBoost)
            {
                currentTime += Time.deltaTime * 2;
            }

            progress.value = (float)currentTime / clearTime;
            durability.value = healthSystem.curHp / healthSystem.maxHp;

            UpdateGoldData();
        }

        else if (gameStartDelay >= 0)
        {
            gameStartDelay -= Time.deltaTime;
        }
        else if (gameClear && !isClearOn)
        {
            UIManager.Instance.ShowUI<UIBase>("GameClearUi", UIRoot);
            isClearOn = true;
            damageIndicator.SetActive(false);
        }
    }

    private void UpdateGoldData()
    {
        gold.text = $"{playerData.gold}G";
        if (playerData.gold > 9999)
        {
            gold.fontSize = 35;
        }
        else if (playerData.gold > 999)
        {
            gold.fontSize = 40;
        }
        else
        {
            gold.fontSize = 50;
        }

        if (currentTime >= clearTime)
        {
            gameClear = true;
        }
    }
}
