using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : Items
{
    private SoundManager soundManager; // SoundManager의 참조
    private GameManager gameManager;

    private void Start()
    {
        soundManager = SoundManager.Instance;
        gameManager = GameManager.Instance;
    }

    public override void ItemEffect(GameObject player)
    {
        gameManager.sleepTimer = 5.0f;
        gameManager.isSleep = false;

        soundManager.PlayItemSound("Coffee");

        // 아이템의 다른 효과들...
        // 아이템 획득 애니메이션 TO DO
        // 플레이어 애니메이션 효과
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 다른 물체와의 충돌 시 효과음을 다시 재생합니다.
        soundManager.PlayItemSound("Coffee");
    }
}
