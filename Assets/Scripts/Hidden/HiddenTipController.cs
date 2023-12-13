using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTipController : MonoBehaviour
{
    [SerializeField] private GameObject description;
    [SerializeField] private GameObject goldTxtBtn;

    private PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Hidden"))
        {
            if(PlayerPrefs.GetInt("Hidden") == 1)
            {
                description.SetActive(true);
                goldTxtBtn.SetActive(false);
            }
            else
            {
                description.SetActive(false);
                goldTxtBtn.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Hidden", 0);
            description.SetActive(false);
            goldTxtBtn.SetActive(true);
        }
        playerData = PlayerData.Instance;
    }
    public void PurchaseGold()
    {
        if (playerData.gold >= 9999)
        {
            playerData.gold -= 9999;
            playerData.goldDataSave();
            PlayerPrefs.SetInt("Hidden", 1);
            goldTxtBtn.SetActive(false);
            description.SetActive(true);
        }
    }
}
