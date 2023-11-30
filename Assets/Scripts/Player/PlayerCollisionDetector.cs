using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    private HealthSystem playerHealth;

    private void Start()
    {
        playerHealth = GetComponentInParent<HealthSystem>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerHealth.UpdateCurHp();
        }
    }
}
