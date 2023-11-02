using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerateManager_Jin : Singleton<ObstacleGenerateManager_Jin>
{
    // 4���� ����
    // ������ ���� �����Ǵ� ��ֹ�(�ڵ���)
    // ���� ��ֹ��� �����Ǵ°�?
    // ��ֹ� �̿��� ���� ������Ʈ�� ���°�? �ִٸ� �� �Ŵ����� ���� ������ �� �ִ°�?
    // 

    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private GameObject PrefabGenPositions;
    
    public List<Transform> prefabGenPos;

    [SerializeField]
    private float obstacleGenDelay = 2.0f;

    private void Awake()
    {
    }

    private void Start()
    {
        Transform prefabPos = PrefabGenPositions.GetComponentInChildren<Transform>();

        foreach (Transform pos in prefabPos)
        {
            prefabGenPos.Add(pos);
        }
        InvokeRepeating(nameof(GenerateObstacle), 1.0f, obstacleGenDelay);
    }

    private void GenerateObstacle()
    {
        Debug.Log("generated");
        Instantiate(obstacle, prefabGenPos[Random.Range(0, 3)]);
    }
}
