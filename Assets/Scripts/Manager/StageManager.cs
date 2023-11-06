using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject spawnPoint;

    [SerializeField] private GameObject boosterPrefab;

    public float clearTime = 120;
    public float currentTime;

    public float maxHp = 100;
    public float curHp;

    private float itemTimer = 0;

    public Slider progress;
    public Slider durability;
    public TMP_Text gold;

    private void Start()
    {
        currentTime = 0;
        gold.text = $"{GameManager.instance.gold} G";
        curHp = maxHp;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        itemTimer += Time.deltaTime;
        progress.value = (float) currentTime / clearTime;
        gold.text = $"{GameManager.instance.gold} G";
        Stage1();

    }

    public void Stage1()
    {
        if (itemTimer > 5)
        {
            int index = Random.Range(0, 4);
            Instantiate(boosterPrefab, spawnPoint.transform.GetChild(0).gameObject.transform.GetChild(index).gameObject.transform);
            itemTimer = 0;
        }
    }
}
