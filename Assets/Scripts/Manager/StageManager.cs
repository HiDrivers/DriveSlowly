using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public float clearTime = 120;
    public float currentTime;

    public float maxHp;
    public float curHp;

    public Slider progress;
    public Slider durability;
    public TMP_Text gold;

    private void Awake()
    {
        currentTime = 0;
        gold.text = "0G"; // GameManager.instance.gold.ToString();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        progress.value = (float) currentTime / clearTime;
    }

    public void Stage1()
    {

    }
}
