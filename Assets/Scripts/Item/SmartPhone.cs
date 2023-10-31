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
        // 아이템 효과음 TO DO
        // 아이템 획득 애니메이션 TO DO
        // 플레이어 애니메이션 효과
        Destroy(this.gameObject);
    }
}
