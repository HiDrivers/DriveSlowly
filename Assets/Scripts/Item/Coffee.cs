using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : Items
{
    private SoundManager soundManager; // SoundManager�� ����

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>(); // �� �ȿ��� SoundManager�� ã�ƿ�
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.sleepTimer = 5.0f;
        GameManager.Instance.isSleep = false;

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
