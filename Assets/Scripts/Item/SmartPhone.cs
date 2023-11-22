using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhone : Items
{
    private SoundManager soundManager; // SoundManager의 참조

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>(); // 씬 안에서 SoundManager를 찾아옴
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.phoneTimer = 5.0f;
        GameManager.Instance.isPhone = true;
        soundManager.PlayItemSound("SmartPhone");

        // 아이템의 다른 효과들...
        // 아이템 획득 애니메이션 TO DO
        // 플레이어 애니메이션 효과
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundManager.PlayItemSound("smartphone");
    }
}

