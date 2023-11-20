using UnityEngine;
using UnityEngine.UI;

public class OpenSettingUiButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        // 버튼 컴포넌트 가져오기
        button = GetComponent<Button>();

        // 버튼이 클릭되면 OpenSettingUI 메서드 실행
        button.onClick.AddListener(OpenSettingUI);
    }

    private void OpenSettingUI()
    {
        // UIManager의 Instance를 통해 SettingUi를 불러옴
        UIManager.Instance.ShowUI<UIBase>("SettingUi", transform);
    }
}

