using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.instance.sleepTimer = 15.0f;
        GameManager.instance.isSleep = true;
        GameManager.instance.PlayerSleepUIControl();
        // ������ ȿ���� TO DO
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }
}
