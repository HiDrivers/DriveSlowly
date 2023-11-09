using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    private GameObject settingPrefab;
    private GameObject gameClearPrefab;
    private GameObject instantiatedSettingUI;
    private GameObject instantiatedGameClearUI;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();

                if (instance == null)
                {
                    GameObject go = new GameObject("UIManager");
                    instance = go.AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }

    private void Start()
    {
        LoadUIPrefabs();
    }

    private void LoadUIPrefabs()
    {
        settingPrefab = Resources.Load<GameObject>("Prefabs/Ui/Setting");
        if (settingPrefab == null)
        {
            Debug.LogError("Setting prefab not found!");
        }

        gameClearPrefab = Resources.Load<GameObject>("Prefabs/Ui/GameClear");
        if (gameClearPrefab == null)
        {
            Debug.LogError("GameClear prefab not found!");
        }
    }

    public void ShowSettingUI()
    {
        if (settingPrefab != null)
        {
            instantiatedSettingUI = Instantiate(settingPrefab);
            Button closeBtn = instantiatedSettingUI.GetComponentInChildren<Button>();
            if (closeBtn != null)
            {
                closeBtn.onClick.AddListener(CloseSettingUI);
            }
            else
            {
                Debug.LogError("CloseSetting button not found!");
            }
        }
        else
        {
            Debug.LogError("Setting prefab not loaded!");
        }
    }

    public void CloseSettingUI()
    {
        if (instantiatedSettingUI != null)
        {
            Destroy(instantiatedSettingUI);
        }
    }

    public void CheckAndShowGameClearUI()
    {
        if (GameManager.Instance != null)
        {
            // 90�ʸ� ��Ƴ����� �� GameClearUI�� ǥ���մϴ�.
            if (GameManager.Instance.currentStage == 1 && GameManager.Instance.boostTimer <= 0)
            {
                ShowGameClearUI();
            }
        }
    }

    private void ShowGameClearUI()
    {
        if (gameClearPrefab != null)
        {
            instantiatedGameClearUI = Instantiate(gameClearPrefab);
            // ���� ���������� ����
            int nextStage = GameManager.Instance.currentStage + 1;
            // ���⼭ ���� ���������� ���� ó���� ������ �� �ֽ��ϴ�.
            switch (nextStage)
            {
                case 2:
                    // 1������������ 2���������� �̵��ϴ� ó��
                    Debug.Log("1���������� Ŭ�����Ͽ� 2���������� �̵��մϴ�.");
                    break;
                case 3:
                    // 2������������ 3���������� �̵��ϴ� ó��
                    Debug.Log("2���������� Ŭ�����Ͽ� 3���������� �̵��մϴ�.");
                    break;
                // �ٸ� ���̽��� ���� ó�� �߰�
                default:
                    Debug.Log("�� �̻��� ���������� �����ϴ�!");
                    break;
            }
        }
        else
        {
            Debug.LogError("GameClear prefab not loaded!");
        }
    }

    public void CloseGameClearUI()
    {
        if (instantiatedGameClearUI != null)
        {
            Destroy(instantiatedGameClearUI);
        }
    }
}


































