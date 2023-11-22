using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : Items
{
    private SoundManager soundManager; // SoundManager의 참조

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.sleepTimer = 15.0f;
        GameManager.Instance.isSleep = true;
        soundManager.PlayItemSound("Pillow");

        // 아이템의 다른 효과들...
        // 아이템 획득 애니메이션 TO DO
        // 플레이어 애니메이션 효과
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundManager.PlayItemSound("Pillow");
    }
}

