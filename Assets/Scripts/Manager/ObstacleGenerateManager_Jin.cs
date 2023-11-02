using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerateManager_Jin : Singleton<ObstacleGenerateManager_Jin>
{
    // 4개의 차선
    // 차선에 맞춰 생성되는 장애물(자동차)
    // 단일 장애물만 생성되는가?
    // 장애물 이외의 생성 오브젝트는 없는가? 있다면 이 매니저로 같이 관리할 수 있는가?
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
