using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool // �̰͵� Pool�̶� �ؾߵǳ�..? �뷮���� ���� ������ �ϳ��� ���� ����
    {
        public string objectTag; // ������ �±�
        public GameObject prefab; // ������ ������Ʈ
        public int amount; // ���� ������ ����
    }

    public List<Pool> pools; // �� ���� ��� �������� �� ��Ƶ� ���
    public Dictionary<string, Queue<GameObject>> poolDictionary; // �����Ǹ� ����� �����Ѵ�.

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            var objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.amount; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.objectTag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag)) return null;

        GameObject obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);

        return obj;
    }
}
