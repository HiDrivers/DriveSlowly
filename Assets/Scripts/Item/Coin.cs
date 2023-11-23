using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Items
{
    private SoundManager soundManager; // SoundManager�� ����

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.gold += 10;
        // ȿ���� TO DO

        // ȹ�� �ִϸ��̼� TO DO
        soundManager.PlayItemSound("Coin");

        gameObject.GetComponent<Animator>().Play("Coin_OnHit");
        Invoke("DestroyThis", 0.3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundManager.PlayItemSound("Coin");
    }
}

