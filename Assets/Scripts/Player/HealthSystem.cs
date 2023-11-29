using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // 플레이어의 현재 상태를 다루는 스크립트, 플레이어 스프라이트 반영도 일단 이 스크립트에서 작성합니다.

    [SerializeField] public GameObject carPrefab;
    [SerializeField] private GameObject tempcarPrefab;
    //[SerializeField] private Animator animator;

    public float curHp;
    public float maxHp;

    //private static readonly int IsHit = Animator.StringToHash("IsHit");

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
        //animator.SetTrigger(IsHit);
    }
}
