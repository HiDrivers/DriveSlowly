using System;
using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private Button buyButton;
    [SerializeField] private Button confirmButton;

    [SerializeField] private GameObject selectedCar;
    private Image selectedCarImage;

    private void Awake()
    {
        selectedCarImage = selectedCar.GetComponent<Image>();
    }

    private void OnEnable()
    {
        buyButton.interactable = false;
        confirmButton.interactable = false;
    }

    private void Start()
    {
        int index = 0;
        foreach (KeyValuePair<Sprite, Sprite> imagePair in carImagePairs)
        {
            carSlots[index].carImage.sprite = imagePair.Key;
            carSlots[index].slotIndex = index;
            index++;
        }
        selectedSlot = null;
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
        if (GameManager.Instance.gold >= selectedSlot.price && selectedSlot.car_UnusableIcon.activeSelf)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }

        confirmButton.interactable = selectedSlot.car_UnusableIcon.activeSelf ? false : true;
    }

    public void BuyCar() // Buy��ư
    {
        if (GameManager.Instance.gold >= selectedSlot.price)
        {
            GameManager.Instance.gold -= selectedSlot.price; // PlayerData.Gold ����
            selectedSlot.car_UnusableIcon.SetActive(false);// selectedSlot.car_UnusableIcon��Ȱ��ȭ
        }
        CheckCarUsability();
    }

    public void ConfirmCar() // Confirm��ư
    {
        selectedCarImage.sprite = selectedSlot.carImage.sprite;
        PlayerData.Instance.carPrefab = carPrefabs[selectedSlot.slotIndex];
        // SelectCarPopup UI â �ݱ�(UI�޴��� ��ũ��Ʈ�� �ֳ�?)
        // gameObject.SetActive(false);
    }
}
