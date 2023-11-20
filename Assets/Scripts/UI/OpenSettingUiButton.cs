using UnityEngine;
using UnityEngine.UI;

public class OpenSettingUiButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        // ��ư ������Ʈ ��������
        button = GetComponent<Button>();

        // ��ư�� Ŭ���Ǹ� OpenSettingUI �޼��� ����
        button.onClick.AddListener(OpenSettingUI);
    }

    private void OpenSettingUI()
    {
        // UIManager�� Instance�� ���� SettingUi�� �ҷ���
        UIManager.Instance.ShowUI<UIBase>("SettingUi", transform);
    }
}

