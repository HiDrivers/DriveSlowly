using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DataReset : MonoBehaviour
{
    [SerializeField] private GameObject ResetUI;

    public void ResetUIControl()
    {
        ResetUI.SetActive(!ResetUI.activeSelf);
    }
    public void GameReset()
    {
        PlayerPrefs.DeleteAll();
        GameManager.Instance.Start();
        PlayerData.Instance.Start();
    }
}
