using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.gold += 10;
        // 효과음 TO DO
        // 획득 애니메이션 TO DO
        Destroy(this.gameObject);
    }
}
