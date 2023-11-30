using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // �÷��̾��� ���� ���¸� �ٷ�� ��ũ��Ʈ, �÷��̾� ��������Ʈ �ݿ��� �ϴ� �� ��ũ��Ʈ���� �ۼ��մϴ�.

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
