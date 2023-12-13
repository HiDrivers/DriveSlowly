using UnityEngine;
using UnityEngine.UI;

public class OpenSettingUiButton : MonoBehaviour
{
    

   

    public void OpenSettingUI()
    {
        // UIManager의 Instance를 통해 SettingUi를 불러옴
        UIBase settingUI = UIManager.Instance.ShowUI<UIBase>("SettingUi", transform);

        // UI 요소를 화면 중앙에 배치하기 위해 RectTransform 사용
        if (settingUI != null)
        {
            RectTransform rectTransform = settingUI.GetComponent<RectTransform>();
            rectTransform.position = new Vector2(Screen.width / 2, Screen.height / 2);
        }
    }


    public void OpenSettingUIwithReset()
    {
        // UIManager의 Instance를 통해 SettingUi를 불러옴
        UIBase settingUI = UIManager.Instance.ShowUI<UIBase>("SettingUIwithReset", transform);

        // UI 요소를 화면 중앙에 배치하기 위해 RectTransform 사용
        if (settingUI != null)
        {
            RectTransform rectTransform = settingUI.GetComponent<RectTransform>();
            rectTransform.position = new Vector2(Screen.width / 2, Screen.height / 2);
        }
    }

}




