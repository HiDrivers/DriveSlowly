using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSlot : MonoBehaviour
{
    private Image carImage;
    [SerializeField] private int price;

    [HideInInspector] public Outline outline;
    public bool selected;

    public int index;

    [SerializeField] private CarSelectController carSelectController;

    private void Awake()
    {
        carImage = GetComponent<Image>();
        outline = GetComponent<Outline>();
    }
    
    void OnEnable()
    {
        outline.enabled = false;
    }

    public void ClickSlotUI()
    {
        selected = true;
        carSelectController.SelectSlot(index);
    }
}
