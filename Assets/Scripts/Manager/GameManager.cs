using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject ControlUI;
    // �� ����
    public int Gold = 0;

    // �������� ����(2��������)
    [Header("Stage 2 Sleepy Drive")]
    public GameObject sleepShade;
    public bool sleepMode = false;
    public bool isSleep = false;
    public float sleepTimer = 0;
    public bool isPhone = false;
    public float phoneTimer = 0;
    public int currentArrow;

    // ���ֿ��� ����(3��������)
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
        // �������� �κ� ��Ʈ��
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
        // ���� �κ� ��Ʈ��
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
        // ����Ʈ�� �κ� ��Ʈ��
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
