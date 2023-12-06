using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionDetector : MonoBehaviour
{
    private HealthSystem playerHealth;
    [SerializeField] private GameObject damagedIndicator;
    private Image damagedPanel;

    [SerializeField] private float damageBlinkInterval = 1f;

    private void Start()
    {
        playerHealth = GetComponentInParent<HealthSystem>();
        //damagedPanel = damagedIndicator.GetComponent<Image>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerHealth.UpdateCurHp();

            //StartCoroutine(GetDamageIndicate());
        }
    }

    //IEnumerator GetDamageIndicate()
    //{
    //    float startAlpha = 0.5f;
    //    float a = startAlpha;
    //    damagedPanel.enabled = true;

    //    while (a > 0f)
    //    {
    //        a -= (startAlpha / damageBlinkInterval) * Time.deltaTime;
    //        damagedPanel.color = new Color(0.8f, 0f, 0f, a);
    //        yield return null;
    //    }

    //    damagedPanel.enabled = false;
    //}
}
