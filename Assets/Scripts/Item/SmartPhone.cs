using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhone : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.instance.phoneTimer = 5.0f;
        GameManager.instance.isPhone = true;
        GameManager.instance.PlayerPhoneUIControl();
        // ������ ȿ���� TO DO
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }
}