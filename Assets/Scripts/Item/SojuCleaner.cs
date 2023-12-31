using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SojuCleaner : Items
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
        gameManager.drunkTimer = 5.0f;
        gameManager.isDrunk = false;

        // 데이터 저장
        gameManager.totalItemCount += 1;
        gameManager.currentSojuCleanerCount += 1;

        soundManager.PlayItemSound("SojuCleaner");

        // 아이템의 다른 효과들...
        // 아이템 획득 애니메이션 TO DO
        // 플레이어 애니메이션 효과
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundManager.PlayItemSound("SojuCleaner");
    }
}

