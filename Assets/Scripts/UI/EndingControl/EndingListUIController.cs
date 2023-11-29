using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class EndingListUIController : MonoBehaviour
{
    [SerializeField] private GameObject _Container;
    private float endingPanelGap = 566f;
    private RectTransform containerRTransform;
    private int pages;
    private int page;

    private string _TextContent;
    [SerializeField] private GameObject pageText;
    private TMP_Text _Text;

    [SerializeField] private GameObject previousArrow;
    [SerializeField] private GameObject nextArrow;
    private Button previousButton;
    private Button nextButton;

    private Vector2 originPos;
    //private Vector2 currentPos;

    private void Awake()
    {
        containerRTransform = _Container.GetComponent<RectTransform>();
        originPos = containerRTransform.anchoredPosition;
    }

    void OnEnable()
    {
        _Text = pageText.GetComponent<TMP_Text>();

        previousButton = previousArrow.GetComponent<Button>();
        nextButton = nextArrow.GetComponent<Button>();

        page = 1;
        pages = _Container.transform.childCount;
        containerRTransform.anchoredPosition = originPos;

        previousButton.interactable = false;
        nextButton.interactable = true;
        UpdatePage();
    }

    public void ChangePage(bool isNext)
    {
        if (isNext)
        {
            containerRTransform.anchoredPosition -= new Vector2(endingPanelGap, 0);
            page++;
        }
        else
        {
            containerRTransform.anchoredPosition += new Vector2(endingPanelGap, 0);
            page--;
        }
        //if (isNext) // 선형 보간을 이용한 부드러운 페이지 넘기기 시도 중
        //{
        //    currentPos = containerRTransform.anchoredPosition - new Vector2(endingPanelGap, 0);
        //    containerRTransform.anchoredPosition = Vector2.Lerp(containerRTransform.anchoredPosition, currentPos, translateSpeed * Time.deltaTime);
        //    page++;
        //}
        //else
        //{
        //    currentPos = containerRTransform.anchoredPosition + new Vector2(endingPanelGap, 0);
        //    containerRTransform.anchoredPosition = Vector2.Lerp(containerRTransform.anchoredPosition, currentPos, translateSpeed * Time.deltaTime);
        //    page--;
        //}
        ReflectInUI();
    }

    private void ReflectInUI()
    {
        if (page == 1)
        {
            previousButton.interactable = false;
        }
        else if (page == pages)
        {
            nextButton.interactable = false;
        }
        else
        {
            previousButton.interactable = true;
            nextButton.interactable = true;
        }
        UpdatePage();
    }

    private void UpdatePage()
    {
        _TextContent = string.Format($"{page}/{pages}");
        _Text.text = _TextContent;
    }
}



