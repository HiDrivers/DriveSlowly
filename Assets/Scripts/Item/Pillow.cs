using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.sleepTimer = 15.0f;
        GameManager.Instance.isSleep = true;
        GameManager.Instance.PlayerSleepUIControl();
        // ������ ȿ���� TO DO
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }
}