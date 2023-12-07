using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSlot : MonoBehaviour
{
    [HideInInspector] public Image carImage;
    public GameObject car_UnusableIcon;
    public int price;
    public string description;

    [HideInInspector] public Outline outline;
    public bool selected; // 필요 없는 변수?
    public int slotIndex;

    private string playerPrefsString;

    [SerializeField] private CarSelectController carSelectController;

    private void Awake()
    {
        carImage = transform.GetChild(0).GetComponent<Image>();
        outline = GetComponent<Outline>();
    }
    
    void OnEnable()
    {
        outline.enabled = false;
        playerPrefsString = $"CarSlot{slotIndex}";
        if(PlayerPrefs.HasKey(playerPrefsString))
        {
            if (PlayerPrefs.GetInt(playerPrefsString) == 1)
            {
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt(playerPrefsString, 0);
        }
    }

    public void ClickSlotUI()
    {
        selected = true;
        carSelectController.SelectSlot(slotIndex);
    }
}
