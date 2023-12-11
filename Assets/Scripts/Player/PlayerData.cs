using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : Singleton<PlayerData>
{
    // ������ �ʿ��ұ�?
    public int gold;
    public GameObject carPrefab;

    public List<GameObject> cars;
    // ���� ������ ���⼭ �����ϴ� �� ���?
    // �κ� ���������� �� ��ü�� �۵��ϰ� �Ѵ�.
    // �������� ���� �����ϸ� Player-CarSprite�� spriteRenderer.Sprite�� carSprite�� �����ؾ� �Ѵ�. �̰͵� �ƴϴ�. �Ʒ��� Player������Ʈ ���� Car_Image������Ʈ�� �� ������ �Ѵ�.
    // Player������Ʈ�� �ٽ� �պ��� �Ѵ�. ������ ������ ��翡 ���� sprite, collider, 3�������������� ������ ȿ�� ��ġ�� �޶����� �����̴�.
    public void Start()
    {
        if (PlayerPrefs.HasKey("Gold"))
        {
            gold = PlayerPrefs.GetInt("Gold");
        }
        else
        {
            gold = 0;
        }
        if (PlayerPrefs.HasKey("CurrentCarIndex"))
        {
            carPrefab = cars[PlayerPrefs.GetInt("CurrentCarIndex")];
        }
        else
        {
            carPrefab = cars[0];
            PlayerPrefs.SetInt("CurrentCarIndex", 0);
        }
    }

    public void goldDataSave()
    {
        PlayerPrefs.SetInt("Gold", gold);
    }
}
