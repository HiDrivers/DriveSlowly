using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Items
{
    private SoundManager soundManager; // SoundManager의 참조
    private GameManager gameManager;
    private PlayerData playerData;

    private int goldValue = 10;

    private void Start()
    {
        soundManager = SoundManager.Instance;
        gameManager = GameManager.Instance;
        playerData = PlayerData.Instance;
        if (PlayerPrefs.GetInt("CurrentCarIndex") == 7)
        {
            goldValue = 12;
        }
    }

    public override void ItemEffect(GameObject player)
    {
        // 아이템 효과
        playerData.gold += goldValue;
        gameObject.GetComponent<Collider2D>().enabled = false;
        // 데이터 저장
        gameManager.totalGoldCount += goldValue;
        gameManager.currentStageGoldCount += goldValue;
        // 효과음 TO DO

        // 획득 애니메이션 TO DO
        soundManager.PlayItemSound("Coin");

        gameObject.GetComponent<Animator>().Play("Coin_OnHit");
        Invoke("DestroyThis", 0.3f);
    }

   
}

