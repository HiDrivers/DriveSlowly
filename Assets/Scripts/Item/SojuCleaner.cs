using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SojuCleaner : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.instance.drunkTimer = 5.0f;
        GameManager.instance.isDrunk = false;
        GameManager.instance.PlayerDrunkUIControl();
        // ������ ȿ���� TO DO
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }
}
