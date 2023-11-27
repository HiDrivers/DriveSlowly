using UnityEngine;

public class Booster : Items
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
        gameManager.boostTimer = 5.0f;
        gameManager.isBoost = true;

        // ������ �浹 �� ȿ������ ���
        soundManager.PlayItemSound("Booster");

        // �������� �ٸ� ȿ����...
        // ������ ȹ�� �ִϸ��̼� TO DO
        // �÷��̾� �ִϸ��̼� ȿ��
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �ٸ� ��ü���� �浹 �� ȿ������ �ٽ� ���
        soundManager.PlayItemSound("Booster");
    }
}