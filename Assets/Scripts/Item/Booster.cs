using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.instance.boostTimer = 5.0f;
        GameManager.instance.isBoost = true;
        // ������ ȿ���� TO DO
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }
}
