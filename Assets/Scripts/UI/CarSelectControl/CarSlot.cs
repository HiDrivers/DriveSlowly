using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSlot : MonoBehaviour
{
    [HideInInspector] public Image carImage;
    public GameObject car_UnusableIcon;
    [SerializeField] private int price;

    [HideInInspector] public Outline outline;
    public bool selected; // 필요 없는 변수?
    public int slotIndex;

    [SerializeField] private CarSelectController carSelectController;

    private void Awake()
    {
        carImage = transform.GetChild(0).GetComponent<Image>();
        outline = GetComponent<Outline>();
    }
    
    void OnEnable()
    {
        outline.enabled = false;
    }

    public void ClickSlotUI()
    {
        selected = true;
        carSelectController.SelectSlot(slotIndex);
    }
}
