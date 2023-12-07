using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionDetector : MonoBehaviour
{
    private HealthSystem playerHealth;
    private GameObject _damagedIndicator;
    private Image _damagedPanel;

    private void Start()
    {
        playerHealth = GetComponentInParent<HealthSystem>();
        _damagedIndicator = playerHealth.damageIndicator;
        _damagedPanel = playerHealth.damagedPanel;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerHealth.UpdateCurHp();

            _damagedPanel.enabled = true;
            StartCoroutine(playerHealth.GetDamageIndicate());
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (_damagedIndicator != null)
        {
            if (_damagedIndicator.activeSelf == true)
            {
                StopCoroutine(playerHealth.GetDamageIndicate());
                _damagedPanel.enabled = false;
            }
        }
    }
}
