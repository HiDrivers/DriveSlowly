using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Items
{
    private SoundManager soundManager; // SoundManager�� ����
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
        // ������ ȿ��
        playerData.gold += goldValue;
        gameObject.GetComponent<Collider2D>().enabled = false;
        // ������ ����
        gameManager.totalGoldCount += goldValue;
        gameManager.currentStageGoldCount += goldValue;
        // ȿ���� TO DO

        // ȹ�� �ִϸ��̼� TO DO
        soundManager.PlayItemSound("Coin");

        gameObject.GetComponent<Animator>().Play("Coin_OnHit");
        Invoke("DestroyThis", 0.3f);
    }

   
}

