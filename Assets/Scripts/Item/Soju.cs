using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soju : Items
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
        gameManager.drunkTimer = 5.0f;
        gameManager.isDrunk = true;

        // ������ ����
        gameManager.totalItemCount += 1;
        gameManager.currentSojuCount += 1;

        soundManager.PlayItemSound("Soju");

        // �������� �ٸ� ȿ����...
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(gameObject);
    }

   
}
