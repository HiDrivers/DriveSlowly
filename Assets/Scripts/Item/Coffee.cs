using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.sleepTimer = 5.0f;
        GameManager.Instance.isSleep = false;
        // 아이템 효과음 TO DO
        // 아이템 획득 애니메이션 TO DO
        // 플레이어 애니메이션 효과
        Destroy(this.gameObject);
    }
}
