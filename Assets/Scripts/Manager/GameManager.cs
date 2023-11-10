using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // 현재 스테이지 관리
    public int currentStage;

    // 돈 관리
    public int gold = 0;

    // 난폭운전 관리 (1스테이지)
    [Header("Stage 1 Reckless Drive")]
    public bool isBoost = false;
    public float boostTimer = 0;


    // 졸음운전 관리(2스테이지)
    [Header("Stage 2 Sleepy Drive")]
    public GameObject sleepShade;
    public bool sleepMode = false;
    public bool isSleep = false;
    public float sleepTimer = 0;

    // 스마트폰 관리
    public bool isPhone = false;
    public float phoneTimer = 0;
    public int currentArrow;

    // 음주운전 관리(3스테이지)
    [Header ("Stage 3 Drunk drive")]
    public bool drunkMode = false;
    public bool isDrunk = false;
    public float drunkTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (drunkMode)
        {
            isDrunk = true;

        }
        if (sleepMode)
        {
            isSleep = true;
        }
    }

    void Update()
    {
        // 난폭운전 부분 컨트롤
        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer < 0)
            {
                boostTimer = 0;
                isBoost = false;
            }
        }
        // 졸음운전 부분 컨트롤
        if (sleepTimer > 0)
        {
            sleepTimer -= Time.deltaTime;
            if (sleepTimer < 0)
            {
                sleepTimer = 0;
                if (sleepMode) isSleep = true;
                else isSleep = false;
            }
        }
        // 음주 부분 컨트롤
        if (drunkTimer > 0)
        {
            drunkTimer -= Time.deltaTime;
            if (drunkTimer < 0)
            {
                drunkTimer = 0;
                if (drunkMode) isDrunk = true;
                else isDrunk = false;
            }
        }
        // 스마트폰 부분 컨트롤
        if (phoneTimer > 0)
        {
            phoneTimer -= Time.deltaTime;
            if (phoneTimer < 0)
            {
                phoneTimer = 0;
                isPhone = false;
            }
        }
    }



}
