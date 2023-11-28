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
        gameManager.sleepTimer = 5.0f;
        gameManager.isSleep = false;

        soundManager.PlayItemSound("Coffee");

        // �������� �ٸ� ȿ����...
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �ٸ� ��ü���� �浹 �� ȿ������ �ٽ� ����մϴ�.
        soundManager.PlayItemSound("Coffee");
    }
}
