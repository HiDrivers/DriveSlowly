using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : Items
{
    private SoundManager soundManager; // SoundManager의 참조

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>(); // 씬 안에서 SoundManager를 찾아옴
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.sleepTimer = 5.0f;
        GameManager.Instance.isSleep = false;

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
