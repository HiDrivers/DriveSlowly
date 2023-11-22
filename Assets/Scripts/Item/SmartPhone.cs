using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhone : Items
{
    private SoundManager soundManager; // SoundManager�� ����

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.phoneTimer = 5.0f;
        GameManager.Instance.isPhone = true;
        soundManager.PlayItemSound("SmartPhone");

        // �������� �ٸ� ȿ����...
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundManager.PlayItemSound("smartphone");
    }
}

