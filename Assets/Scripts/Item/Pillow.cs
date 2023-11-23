using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : Items
{
    private SoundManager soundManager; // SoundManager�� ����

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.sleepTimer = 15.0f;
        GameManager.Instance.isSleep = true;
        soundManager.PlayItemSound("Pillow");

        // �������� �ٸ� ȿ����...
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundManager.PlayItemSound("Pillow");
    }
}

