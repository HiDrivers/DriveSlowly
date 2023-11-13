using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject endingListPanel;
    public GameObject carListPanel;

    public void ShowPopup(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePopup(GameObject panel)
    {
        panel.SetActive(false);
    }
}

