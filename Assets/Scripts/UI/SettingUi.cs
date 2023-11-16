using UnityEngine;
using UnityEngine.UI;

public class SettingUI : UIBase
{
    public GameObject settingPanel; // SettingUI �г�
    public Button closeButton; // closeButton �߰�

    // Start �Լ��� �����մϴ�.

    public void CloseSettingUI()
    {
        if (settingPanel != null)
        {
            settingPanel.SetActive(false); // SettingUI �����
        }
        else
        {
            Debug.LogError("Setting Panel is not assigned!");
        }
    }
}






























