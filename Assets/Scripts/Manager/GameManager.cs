using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject ControlUI;
    // 돈 관리
    public int Gold = 0;

    // 졸음운전 관리(2스테이지)
    [Header("Stage 2 Sleepy Drive")]
    public GameObject sleepShade;
    public bool sleepMode = false;
    public bool isSleep = false;
    public float sleepTimer = 0;
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
        instance = this;
        PlayerDrunkUIControl();
        if (drunkMode)
        {
            isDrunk = true;
            PlayerDrunkUIControl();
        }
        if (sleepMode)
        {
            isSleep = true;
            PlayerSleepUIControl();
        }
    }

    void Update()
    {
        // 졸음운전 부분 컨트롤
        if (sleepTimer > 0)
        {
            sleepTimer -= Time.deltaTime;
            if (sleepTimer < 0)
            {
                sleepTimer = 0;
                if (sleepMode) isSleep = true;
                else isSleep = false;
                PlayerSleepUIControl();
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
                PlayerDrunkUIControl();
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
                PlayerPhoneUIControl();
            }
        }
    }

    public void PlayerSleepUIControl()
    {
        sleepShade.SetActive(isSleep);
    }

    public void PlayerDrunkUIControl()
    {
        ControlUI.transform.GetChild(0).gameObject.SetActive(!isDrunk);
        ControlUI.transform.GetChild(1).gameObject.SetActive(isDrunk);
    }

    public void PlayerPhoneUIControl()
    {
        if (isPhone)
        {
            currentArrow = Random.Range(0, 4);
            ControlUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(currentArrow).gameObject.SetActive(false);
        }
        else
        {
            ControlUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(currentArrow).gameObject.SetActive(true);
        }
    }

}
