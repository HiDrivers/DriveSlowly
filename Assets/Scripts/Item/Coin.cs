using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Items
{
    private SoundManager soundManager; // SoundManager�� ����
    private GameManager gameManager;

    private void Start()
    {
        soundManager = SoundManager.Instance;
        gameManager = GameManager.Instance;
    }

    public override void ItemEffect(GameObject player)
    {
        // ������ ȿ��
        gameManager.gold += 10;

        // ������ ����
        gameManager.currentGoldCount += 10;

        // ȿ���� TO DO

        // ȹ�� �ִϸ��̼� TO DO
        soundManager.PlayItemSound("Coin");

        gameObject.GetComponent<Animator>().Play("Coin_OnHit");
        Invoke("DestroyThis", 0.3f);
    }

   
}

