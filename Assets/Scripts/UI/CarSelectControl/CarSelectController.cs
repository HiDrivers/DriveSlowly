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

    public void BuyCar() // Buy버튼
    {
        // PlayerData.Gold 차감
        // selectedSlot.car_UnusableIcon비활성화
        // CheckCarUsability() 메서드 실행
    }

    public void ConfirmCar() // Confirm버튼
    {
        selectedCarImage.sprite = selectedSlot.carImage.sprite;
        // SelectCarPopup UI 창 닫기(UI메니저 스크립트에 있나?)
    }
}
