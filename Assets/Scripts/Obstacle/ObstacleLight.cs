using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLight : MonoBehaviour
{
    [SerializeField] private GameObject leftLamp, rightLamp;
    [SerializeField] private float blinkSpeed = 1.0f;
    private bool lampBlink;

    private Coroutine coroutine;
    private void Start()
    {
        lampBlink = false;
        leftLamp.SetActive(false);
        rightLamp.SetActive(false);
    }

    internal void TurnOnLight()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(BlinkLamps());
    }

    private IEnumerator BlinkLamps()
    {
        float blinkInterval = 0.5f;
        while (true)
        {
            lampBlink = !lampBlink;
            leftLamp.SetActive(lampBlink);
            rightLamp.SetActive(!lampBlink);

            yield return new WaitForSeconds(blinkInterval * blinkSpeed);
        }
    }
}