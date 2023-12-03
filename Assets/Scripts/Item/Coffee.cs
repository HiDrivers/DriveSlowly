using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : Items
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
        gameManager.sleepTimer = 5.0f;
        gameManager.isSleep = false;

        // ������ ����
        gameManager.totalItemCount += 1;
        gameManager.currentCoffeeCount += 1;

        soundManager.PlayItemSound("Coffee");

        // �������� �ٸ� ȿ����...
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }

   
}
