using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CarImagePairs : SerializableDictionary<Sprite, Sprite> { }

public class CarSelectController : MonoBehaviour
{
    [SerializeField] private CarImagePairs carImagePairs;
    [SerializeField] private GameObject[] carPrefabs;

    public CarSlot[] carSlots;
    [SerializeField] private CarSlot selectedSlot;


    [SerializeField] private GameObject buyButton;
    [SerializeField] private GameObject confirmButton;
    private Button _buy;

    [SerializeField] private GameObject selectedCar;
    private Image selectedCarImage;

    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI carDescriptionText;
    [SerializeField] private TextMeshProUGUI carPriceText;

    private PlayerData playerData;

    private void Awake()
    {
        playerData = PlayerData.Instance;
        selectedCarImage = selectedCar.GetComponent<Image>();

        _buy = buyButton.GetComponent<Button>();
    }

    private void OnEnable()
    {
        _buy.interactable = false;
        buyButton.SetActive(false);
        confirmButton.SetActive(true);
    }

    private void Start()
    {
        int index = 0;
        foreach (KeyValuePair<Sprite, Sprite> imagePair in carImagePairs)
        {
            carSlots[index].carImage.sprite = imagePair.Value;
            carSlots[index].slotIndex = index;
            index++;
        }
        selectedSlot = null;

        UpdateCurrentGold();
    }

    private void UpdateCurrentGold()
    {
        goldText.text = string.Format("소지금\n{0:0} G", playerData.gold);
    }

    public void SelectSlot(int index)
    {
        for (int i = 0; i < carSlots.Length; i++)
        {
            if (selectedSlot == null || selectedSlot != carSlots[index])
            {
                selectedSlot = carSlots[index];
                carSlots[index].outline.enabled = true;
            }
        }

        UpdateOutLine();
        UpdateSelectedCarInfo(index);
    }

    private void UpdateSelectedCarInfo(int index)
    {
        carDescriptionText.text = carSlots[index].description;
        carPriceText.text = string.Format("{0:0} G", carSlots[index].price.ToString());
    }

    private void UpdateOutLine()
    {
        for (int i = 0; i < carSlots.Length; i++)
        {
            if (carSlots[i] == selectedSlot) carSlots[i].outline.enabled = true;
            else carSlots[i].outline.enabled = false;
        }

        CheckCarUsability();
    }

    private void CheckCarUsability()
    {
        bool canBuy = playerData.gold >= selectedSlot.price;
        bool bought = !selectedSlot.car_UnusableIcon.activeSelf;

        if (bought)
        {
            buyButton.SetActive(false);
        }
        else if (canBuy && !bought)
        {
            buyButton.SetActive(true);
            _buy.interactable = true;
        }
        else
        {
            buyButton.SetActive(true);
            _buy.interactable = false;
        }
        confirmButton.SetActive(!buyButton.activeSelf);
    }

    public void BuyCar() // Buy버튼
    {
        playerData.gold -= selectedSlot.price; // PlayerData.Gold 차감
        selectedSlot.car_UnusableIcon.SetActive(false);

        UpdateCurrentGold();
        CheckCarUsability();
    }

    public void ConfirmCar() // Confirm버튼
    {
        selectedCarImage.sprite = selectedSlot.carImage.sprite;
        playerData.carPrefab = carPrefabs[selectedSlot.slotIndex];
        // SelectCarPopup UI 창 닫기(UI메니저 스크립트에 있나?)
        // gameObject.SetActive(false);
    }
}
