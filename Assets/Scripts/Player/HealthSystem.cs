using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // 플레이어의 현재 상태를 다루는 스크립트, 플레이어 스프라이트 반영도 일단 이 스크립트에서 작성합니다.

    public GameObject carPrefab;
    [HideInInspector] public GameObject _car;

    public float curHp;
    public float maxHp;

    private void Awake()
    {
        if (carPrefab == null)
        {
            carPrefab = PlayerData.Instance.carPrefab;
        }
        else carPrefab = null;
    }

    private void OnEnable()
    {
        _car = Instantiate(carPrefab, Vector3.zero, Quaternion.identity);
        _car.transform.SetParent(transform);
    }
    private void Start()
    {
        curHp = maxHp;
    }

    internal void UpdateCurHp()
    {
        curHp -= Time.deltaTime;
    }
}
