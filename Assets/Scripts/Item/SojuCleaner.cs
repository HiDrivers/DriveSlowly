using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SojuCleaner : Items
{
    private SoundManager soundManager; // SoundManager�� ����

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.drunkTimer = 5.0f;
        GameManager.Instance.isDrunk = false;
        soundManager.PlayItemSound("SojuCleaner");

        // �������� �ٸ� ȿ����...
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundManager.PlayItemSound("SojuCleaner");
    }
}

