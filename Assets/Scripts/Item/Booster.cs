using UnityEngine;

public class Booster : Items
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
        gameManager.boostTimer = 5.0f;
        gameManager.isBoost = true;

        // 아이템 충돌 시 효과음을 재생
        soundManager.PlayItemSound("Booster");

        // 아이템의 다른 효과들...
        // 아이템 획득 애니메이션 TO DO
        // 플레이어 애니메이션 효과
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 다른 물체와의 충돌 시 효과음을 다시 재생
        soundManager.PlayItemSound("Booster");
    }
}