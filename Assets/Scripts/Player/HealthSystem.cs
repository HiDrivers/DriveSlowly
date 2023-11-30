using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // �÷��̾��� ���� ���¸� �ٷ�� ��ũ��Ʈ, �÷��̾� ��������Ʈ �ݿ��� �ϴ� �� ��ũ��Ʈ���� �ۼ��մϴ�.

    public GameObject carPrefab;

    public float curHp;
    public float maxHp;

    private void Awake()
    {
        //if (carPrefab == null)
        //{
        carPrefab = PlayerData.Instance.carPrefab;
        //}
        //else carPrefab = null;
    }

    private void OnEnable()
    {
    }
    private void Start()
    {
        var carPrefabPos = Instantiate(carPrefab);
        carPrefabPos.transform.SetParent(transform);
        gameObject.GetComponent<PlayerAnimationControl>().Initialize();
        gameObject.GetComponent<PlayerControl>().carPrefab = carPrefab;

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
