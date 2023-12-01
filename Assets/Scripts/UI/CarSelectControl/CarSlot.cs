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
    public bool selected; // �ʿ� ���� ����?
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
