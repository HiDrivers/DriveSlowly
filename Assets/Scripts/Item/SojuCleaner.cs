using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SojuCleaner : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.drunkTimer = 5.0f;
        GameManager.Instance.isDrunk = false;
        GameManager.Instance.PlayerDrunkUIControl();
        // ������ ȿ���� TO DO
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }
}
