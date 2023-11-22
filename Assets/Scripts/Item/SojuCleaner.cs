using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SojuCleaner : Items
{
    private SoundManager soundManager; // SoundManager의 참조

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>(); // 씬 안에서 SoundManager를 찾아옴
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.drunkTimer = 5.0f;
        GameManager.Instance.isDrunk = false;
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

