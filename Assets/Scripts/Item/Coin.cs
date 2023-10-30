using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Items
{
    public override void ItemEffect(GameObject player)
    {
        GameManager.instance.Gold += 10;
        // È¿°úÀ½ TO DO

        Destroy(this.gameObject);
    }
}
