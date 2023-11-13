using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool // 이것도 Pool이라 해야되나..? 대량으로 만들어낼 프리팹 하나에 대한 정보
    {
        public string objectTag; // 프리팹 태그
        public GameObject prefab; // 프리팹 오브젝트
        public int amount; // 만들어낼 프리팹 갯수
    }

    public List<Pool> pools; // 위 생성 대상 프리팹을 다 모아둔 목록
    public Dictionary<string, Queue<GameObject>> poolDictionary; // 생성되면 여기다 저장한다.

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
