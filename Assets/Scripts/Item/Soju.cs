using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soju : Items
{
    private SoundManager soundManager; // SoundManager�� ����

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>(); // �� �ȿ��� SoundManager�� ã�ƿ�
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.drunkTimer = 5.0f;
        GameManager.Instance.isDrunk = true;
        soundManager.PlayItemSound("Soju");

        // �������� �ٸ� ȿ����...
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundManager.PlayItemSound("Soju");
    }
}
