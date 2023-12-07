using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    public void GoldDataSave()
    {
        PlayerPrefs.SetInt("Gold", PlayerData.Instance.gold);
    }
}
