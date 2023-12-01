using UnityEngine;
using UnityEngine.UI;

public class OpenSettingUiButton : MonoBehaviour
{
    

   

    public void OpenSettingUI()
    {
        // UIManager�� Instance�� ���� SettingUi�� �ҷ���
        UIBase settingUI = UIManager.Instance.ShowUI<UIBase>("SettingUI", transform);

        // UI ��Ҹ� ȭ�� �߾ӿ� ��ġ�ϱ� ���� RectTransform ���
        if (settingUI != null)
        {
            RectTransform rectTransform = settingUI.GetComponent<RectTransform>();
            rectTransform.position = new Vector2(Screen.width / 2, Screen.height / 2);
        }
    }
}




