using UnityEngine;

public class Booster : Items
{
    private SoundManager soundManager; // SoundManager�� ����

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>(); // �� �ȿ��� SoundManager�� ã�ƿ�
    }

    public override void ItemEffect(GameObject player)
    {
        GameManager.Instance.boostTimer = 5.0f;
        GameManager.Instance.isBoost = true;

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