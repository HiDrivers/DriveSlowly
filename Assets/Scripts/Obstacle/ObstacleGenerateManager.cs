using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;



public class ObstacleGenerateManager : MonoBehaviour
{
    public Vector3[] obstacleGenPositions // 장애물, 아이템 생성 위치를 GameObject.Transform->Vector3의 집합으로 변경합니다.
        = new Vector3[] {new Vector3(-1.8f, 6f,0), new Vector3(-0.6f,6f,0f), new Vector3(0.6f,6f,0f), new Vector3(1.8f,6f,0f),
            new Vector3(-1.8f, -6f,0), new Vector3(-0.6f,-6f,0f), new Vector3(0.6f,-6f,0f), new Vector3(1.8f,-6f,0f)};

    public List<int> spawnPosCount = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 });

    [SerializeField] private List<GameObject> obstaclePool = new List<GameObject>();

    [SerializeField] private List<GameObject> obstacleList = new List<GameObject>();

    private int maxObstacles = 10;

    private void Start()
    {
        CreateObstaclePool();
    }

    public void CreateObstacle()
    {
        int pos = Random.Range(0, spawnPosCount.Count);
        while (spawnPosCount[(pos + 4) % spawnPosCount.Count] > 0)
        {
            pos = (pos + 1) % spawnPosCount.Count; // pos = 7이고 spawnPosCount[7]이 0이 아니면 다시 pos = 1로 가서 돌아야한다.
        }
        spawnPosCount[pos]++;
        bool isBottom = (pos > 3);
        var _obstacle = GetGenPosition(isBottom);
        _obstacle.GetComponent<Obstacle>().pos = pos;

        Vector3 genPos = obstacleGenPositions[pos];
        Quaternion genRot = Quaternion.Euler(Vector3.zero);

        _obstacle.transform.SetPositionAndRotation(genPos, genRot);
        _obstacle.SetActive(true);
    }

    private GameObject GetGenPosition(bool isBottom)
    {
        foreach (var _obstacle in obstaclePool)
        {
            if (!_obstacle.activeSelf && _obstacle.GetComponent<Obstacle>().isFromBottom == isBottom)
            {
                return _obstacle;
            }
        }
        return null;
    }

    public void CreateObstaclePool()
    {
        for (int j = 0; j < maxObstacles; j++)
        {
            for (int i = 0; i < obstacleList.Count; i++)
            {
                GameObject _obs1 = Instantiate(obstacleList[i]);
                _obs1.name = $"{obstacleList[i].name}_{j:00}";
                _obs1.GetComponent<Obstacle>().ObstacleManager = this.gameObject;
                _obs1.SetActive(false);
                obstaclePool.Add(_obs1);
            }
        }
    }
}
