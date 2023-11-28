using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelectController : MonoBehaviour
{
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
    public void Start()
    {
        for (int i = 0; i < carSlots.Length; i++)
        {
            carSlots[i].slotIndex = i;
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
    }

    private void CheckCarUsability()
    {
        buyButton.interactable = selectedSlot.car_UnusableIcon.activeSelf ? false : true;
        confirmButton.interactable = buyButton.interactable ? false : true;
    }

    public void BuyCar() // Buy��ư
    {
        // PlayerData.Gold ����
        // selectedSlot.car_UnusableIcon��Ȱ��ȭ
        // CheckCarUsability() �޼��� ����
    }

    public void ConfirmCar() // Confirm��ư
    {
        selectedCarImage.sprite = selectedSlot.carImage.sprite;
        // SelectCarPopup UI â �ݱ�(UI�޴��� ��ũ��Ʈ�� �ֳ�?)
    }
}
