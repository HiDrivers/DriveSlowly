using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;



public class ObstacleGenerateManager_Jin : Singleton<ObstacleGenerateManager_Jin>
{
    // 4���� ����
    // ������ ���� �����Ǵ� ��ֹ�(�ڵ���)
    // ���� ��ֹ��� �����Ǵ°�?
    // ��ֹ� �̿��� ���� ������Ʈ�� ���°�? ���� ������ ��ֹ��� �� �Ŵ����� �Ѳ����� ������ �� �ִ°�?
    // 

    // �۸�� �ּ�ó��
    [SerializeField] private GameObject topObstacleGenPositions;
    [SerializeField] private GameObject bottomObstacleGenPositions;

    //public List<Transform> obstaclePositionGroup;

    [SerializeField]
    private List<GameObject> obstaclePool = new List<GameObject>();
    //public Queue<int> occupiedList = new Queue<int>();

    [SerializeField]
    private GameObject obstacle1, obstacle2;

    private int maxObstacles = 20;

    //[SerializeField]
    //private float obstacleGenDelay = 2.0f;

    private void Start()
    {
        // �۸�� �ּ�ó��
        //Transform _obstaclePos = obstacleGenPositions.GetComponentInChildren<Transform>();
        //Debug.Log("Operated");
        //foreach (Transform position in _obstaclePos)
        //{
        //    obstaclePositionGroup.Add(position);
        //}

        CreateObstaclePool();

        // InvokeRepeating(nameof(CreateObstacle), 5.0f, 5.0f);
        CreateObstacle();
    }

    private void CreateObstacle()
    {
        //int index = Random.Range(0, obstaclePositionGroup.Count); // �۸�� �ּ�ó��
        int index = Random.Range(0, 4);
        var _obstacle = GetGenPosition();

        Vector3 genPos = new Vector3();
        quaternion genRot;

        if (_obstacle.name.Contains("Bottom"))
        {
            genPos = bottomObstacleGenPositions.transform.GetChild(index).gameObject.transform.position;
            genRot = bottomObstacleGenPositions.transform.GetChild(index).gameObject.transform.rotation;
        }
        else
        {
            genPos = topObstacleGenPositions.transform.GetChild(index).gameObject.transform.position;
            genRot = topObstacleGenPositions.transform.GetChild(index).gameObject.transform.rotation;
        }

        _obstacle.transform.SetPositionAndRotation(genPos, genRot);
        _obstacle.SetActive(true);
    }

    private GameObject GetGenPosition()
    {
        GameObject _obs = obstaclePool[Random.Range(0, maxObstacles)]; // ������ ������Ʈ �� Ȱ��ȭ�� ������Ʈ�� �������� ���� �ڵ�. �׽�ƮX
        if (!_obs.activeSelf)
        {
            return _obs;
        }
        //foreach (var _obstacle in obstaclePool)
        //{
        //    if (!_obstacle.activeSelf)
        //    {
        //        return _obstacle;
        //    }
        //}
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
