using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhone : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.phoneTimer = 5.0f;
        GameManager.Instance.isPhone = true;
        // ������ ȿ���� TO DO
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }
}
