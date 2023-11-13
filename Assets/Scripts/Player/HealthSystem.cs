using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float curHp;
    public float maxHp;

    private void Start()
    {
        curHp = maxHp;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            curHp -= Time.deltaTime;
        }
    }
}
