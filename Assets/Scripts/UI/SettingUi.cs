using UnityEngine;
using UnityEngine.UI;

public class SettingUI : UIBase
{
    public GameObject settingPanel; // SettingUI 패널
    public Button closeButton; // closeButton 추가

    // Start 함수는 제거합니다.

    public void CloseSettingUI()
    {
        if (settingPanel != null)
        {
            settingPanel.SetActive(false); // SettingUI 숨기기
        }
        else
        {
            Debug.LogError("Setting Panel is not assigned!");
        }
    }
}






























