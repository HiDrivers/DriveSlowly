using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soju : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.instance.drunkTimer = 5.0f;
        GameManager.instance.isDrunk = true;
        GameManager.instance.PlayerDrunkUIControl();
        // ������ ȿ���� TO DO
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }
}
