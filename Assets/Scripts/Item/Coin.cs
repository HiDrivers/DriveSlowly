using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Items
{
    private SoundManager soundManager; // SoundManager의 참조

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.gold += 10;
        // 효과음 TO DO

        // 획득 애니메이션 TO DO
        soundManager.PlayItemSound("Coin");

        gameObject.GetComponent<Animator>().Play("Coin_OnHit");
        Invoke("DestroyThis", 0.3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundManager.PlayItemSound("Coin");
    }
}

