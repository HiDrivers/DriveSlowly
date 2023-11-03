using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;



public class ObstacleGenerateManager_Jin : Singleton<ObstacleGenerateManager_Jin>
{
    // 4���� ����
    // ������ ���� �����Ǵ� ��ֹ�(�ڵ���)
    // ���� ��ֹ��� �����Ǵ°�?
    // ��ֹ� �̿��� ���� ������Ʈ�� ���°�? ���� ������ ��ֹ��� �� �Ŵ����� �Ѳ����� ������ �� �ִ°�?
    // 

    [SerializeField]
    private GameObject obstacleGenPositions;

    public List<Transform> obstaclePositionGroup;

    [SerializeField]
    private List<GameObject> obstaclePool = new List<GameObject>();
    public Queue<int> occupiedList = new Queue<int>();

    [SerializeField]
    private GameObject obstacle1, obstacle2;

    private int maxObstacles = 20;

    [SerializeField]
    private float obstacleGenDelay = 2.0f;

    private void Start()
    {
        Transform _obstaclePos = obstacleGenPositions.GetComponentInChildren<Transform>();
        Debug.Log("Operated");
        foreach (Transform position in _obstaclePos)
        {
            obstaclePositionGroup.Add(position);
        }

        CreateObstaclePool();

        InvokeRepeating(nameof(CreateObstacle), 1.0f, 1.0f);
    }

    private void CreateObstacle()
    {
        int index = Random.Range(0, obstaclePositionGroup.Count);

        if (index != occupiedList.Peek())
        {
            var _obstacle = GetGenPosition();

            Vector3 genPos = new Vector3();
            if (_obstacle.name.Contains("Bottom"))
            {
                genPos = new Vector3(obstaclePositionGroup[index].position.x, obstaclePositionGroup[index].position.y - 7f, obstaclePositionGroup[index].position.z);
            }
            else
            {
                genPos = new Vector3(obstaclePositionGroup[index].position.x, obstaclePositionGroup[index].position.y + 7f, obstaclePositionGroup[index].position.z);
            }

            _obstacle.transform.SetPositionAndRotation(genPos, obstaclePositionGroup[index].rotation);
            _obstacle.SetActive(true);
            occupiedList.Enqueue(index);
        }
    }

    private GameObject GetGenPosition()
    {
        //GameObject _obs = obstaclePool[Random.Range(0, maxObstacles)]; // ������ ������Ʈ �� Ȱ��ȭ�� ������Ʈ�� �������� ���� �ڵ�. �׽�ƮX
        //if (!_obs.activeSelf)
        //{
        //    return _obs;
        //}
        foreach (var _obstacle in obstaclePool)
        {
            if (!_obstacle.activeSelf)
            {
                return _obstacle;
            }
        }
        return null;
    }

    private void CreateObstaclePool()
    {
        for (int i = 0; i < maxObstacles/2; i++)
        {
            GameObject _obstacle1 = Instantiate(obstacle1);
            GameObject _obstacle2 = Instantiate(obstacle2);
            _obstacle1.name = $"obstacleFromTop{i:00}";
            _obstacle2.name = $"obstacleFromBottom{i:00}";
            _obstacle1.SetActive(false);
            _obstacle2.SetActive(false);
            obstaclePool.Add(_obstacle1);
            obstaclePool.Add(_obstacle2);
        }
    }
}
