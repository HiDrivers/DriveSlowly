using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldTxtUI : MonoBehaviour
{
    public TMP_Text goldTxt;
    private void OnEnable()
    {
        goldTxt.text = $"{GameManager.Instance.currentGoldCount}G";
    }
}
