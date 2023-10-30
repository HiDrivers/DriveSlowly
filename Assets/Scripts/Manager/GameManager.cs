using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject ControlUI;
    // �� ����
    public int Gold = 0;

    // ���ֺκ� ����(3��������)
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
        if (!drunkMode)
        {
            if (isDrunk)
            {
                drunkTimer -= Time.deltaTime;
                if (drunkTimer < 0)
                {
                    drunkTimer = 0;
                    isDrunk = false;
                    PlayerDrunkUIControl();
                }
            }
        }

        else
        {
            if (!isDrunk)
            {
                drunkTimer -= Time.deltaTime;
                if (drunkTimer < 0)
                {
                    drunkTimer = 0;
                    isDrunk = true;
                    PlayerDrunkUIControl();
                }
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

}
