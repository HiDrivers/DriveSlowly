using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.gold += 10;
        // ȿ���� TO DO
        // ȹ�� �ִϸ��̼� TO DO
        Destroy(this.gameObject);
    }
}
