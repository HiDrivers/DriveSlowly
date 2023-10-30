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
    [Header ("Stage 2 Sleepy Drive")]
    public bool sleepMode = false;
    public bool isSleep = false;
    public float sleepTimer = 0;
    public bool isPhone = false;
    public float phoneTimer = 0;
    private int currentArrow;

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
    }

    void Update()
    {
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

    public void PlayerDrunkUIControl()
    {
        if (isDrunk)
        {
            ControlUI.transform.GetChild(0).gameObject.SetActive(false);
            ControlUI.transform.GetChild(1).gameObject.SetActive(true);
        }

        else
        {
            ControlUI.transform.GetChild(0).gameObject.SetActive(true);
            ControlUI.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void PlayerPhoneUIControl()
    {
        if (isPhone)
        {
            currentArrow = Random.Range(0, 4);
            ControlUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(currentArrow).gameObject.SetActive(false);
        }
        else
        {
            ControlUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(currentArrow).gameObject.SetActive(true);
        }
    }

}
