using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // �÷��̾��� ���� ���¸� �ٷ�� ��ũ��Ʈ, �÷��̾� ��������Ʈ �ݿ��� �ϴ� �� ��ũ��Ʈ���� �ۼ��մϴ�.

    [SerializeField] public GameObject carPrefab;
    [SerializeField] private GameObject tempcarPrefab;

    public float curHp;
    public float maxHp;

    //private void Awake()
    //{
    //    carPrefab = tempcarPrefab;
    //}

    private void Start()
    {
        curHp = maxHp;
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        curHp -= Time.deltaTime;
    //    }
    //}

    internal void UpdateCurHp()
    {
        curHp -= Time.deltaTime;
    }
}
