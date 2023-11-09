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
            // 90초를 살아남았을 때 GameClearUI를 표시합니다.
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
            // 다음 스테이지로 진행
            int nextStage = GameManager.Instance.currentStage + 1;
            // 여기서 다음 스테이지에 대한 처리를 진행할 수 있습니다.
            switch (nextStage)
            {
                case 2:
                    // 1스테이지에서 2스테이지로 이동하는 처리
                    Debug.Log("1스테이지를 클리어하여 2스테이지로 이동합니다.");
                    break;
                case 3:
                    // 2스테이지에서 3스테이지로 이동하는 처리
                    Debug.Log("2스테이지를 클리어하여 3스테이지로 이동합니다.");
                    break;
                // 다른 케이스에 대한 처리 추가
                default:
                    Debug.Log("더 이상의 스테이지가 없습니다!");
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


































