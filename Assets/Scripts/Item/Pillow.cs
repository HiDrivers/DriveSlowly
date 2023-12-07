using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : Items
{
    private SoundManager soundManager; // SoundManager�� ����
    private GameManager gameManager;

    private void Start()
    {
        soundManager = SoundManager.Instance;
        gameManager = GameManager.Instance;
    }

    public override void ItemEffect(GameObject player)
    {
        // ������ �⺻ ȿ��
        gameManager.sleepTimer = 15.0f;
        gameManager.isSleep = true;

        // ������ ����
        gameManager.totalItemCount += 1;
        gameManager.currentPillowCount += 1;

        soundManager.PlayItemSound("Pillow");

        // �������� �ٸ� ȿ����...
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(gameObject);
    }

    
}

