using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : Items
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
        // 아이템 기본 효과
        gameManager.sleepTimer = 15.0f;
        gameManager.isSleep = true;

        // 데이터 저장
        gameManager.totalItemCount += 1;
        gameManager.currentPillowCount += 1;

        soundManager.PlayItemSound("Pillow");

        // 아이템의 다른 효과들...
        // 아이템 획득 애니메이션 TO DO
        // 플레이어 애니메이션 효과
        Destroy(gameObject);
    }

    
}

