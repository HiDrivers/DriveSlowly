using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.boostTimer = 5.0f;
        GameManager.Instance.isBoost = true;
        // ������ ȿ���� TO DO
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }
}
