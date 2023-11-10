using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

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

    [SerializeField] private Slider progressSlider;
    [SerializeField] private GameObject settingPrefab;
    [SerializeField] private GameObject gameClearUiPrefab;
    [SerializeField] private GameObject selectUiPrefab;

    private GameObject instantiatedSettingUI;
    private GameObject instantiatedGameClearUI;

    private bool hasGameClearUIShown = false;

    private void Awake()
    {
        progressSlider = FindObjectOfType<Slider>();

        if (progressSlider == null)
        {
            Debug.LogError("ProgressSlider�� ã�� �� �����ϴ�! ProgressSlider�� Unity Editor���� ���� �Ҵ��ϼ���.");
            return;
        }

        LoadUIPrefabs();
        progressSlider.onValueChanged.AddListener(OnSliderValueChanged);
        StartCoroutine(CheckGameClearCondition());
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "CutScene2_0")
        {
            StartCoroutine(ShowSelectUiAfterDelay(10f));
        }
    }

    private IEnumerator ShowSelectUiAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (selectUiPrefab != null)
        {
            GameObject instantiatedSelectUI = Instantiate(selectUiPrefab);
            Button closeBtn = instantiatedSelectUI.GetComponentInChildren<Button>();

            if (closeBtn != null)
            {
                closeBtn.onClick.AddListener(CloseSelectUI);
            }
            else
            {
                Debug.LogError("CloseSelect ��ư�� ã�� �� �����ϴ�!");
            }
        }
        else
        {
            Debug.LogError("SelectUi �������� �ε��� �� �����ϴ�!");
        }
    }

    private void OnSliderValueChanged(float value)
    {
        if (value == 1f && !hasGameClearUIShown)
        {
            ShowGameClearUI();
            hasGameClearUIShown = true;
        }
    }

    private void LoadUIPrefabs()
    {
        settingPrefab = Resources.Load<GameObject>("Prefabs/Ui/Setting");
        if (settingPrefab == null)
        {
            Debug.LogError("Setting �������� ã�� �� �����ϴ�!");
        }

        gameClearUiPrefab = Resources.Load<GameObject>("Prefabs/Ui/GameClearUi");
        if (gameClearUiPrefab == null)
        {
            Debug.LogError("GameClearUi �������� ã�� �� �����ϴ�!");
        }

        selectUiPrefab = Resources.Load<GameObject>("Prefabs/Ui/SelectUi");
        if (selectUiPrefab == null)
        {
            Debug.LogError("SelectUi �������� ã�� �� �����ϴ�!");
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
                Debug.LogError("CloseSetting ��ư�� ã�� �� �����ϴ�!");
            }
        }
        else
        {
            Debug.LogError("Setting �������� �ε��� �� �����ϴ�!");
        }
    }

    public void CloseSettingUI()
    {
        if (instantiatedSettingUI != null)
        {
            Destroy(instantiatedSettingUI);
        }
    }

    private IEnumerator CheckGameClearCondition()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (progressSlider.value == 1f && !hasGameClearUIShown)
            {
                ShowGameClearUI();
                hasGameClearUIShown = true;
            }
        }
    }

    private void ShowGameClearUI()
    {
        if (gameClearUiPrefab != null)
        {
            instantiatedGameClearUI = Instantiate(gameClearUiPrefab);
        }
        else
        {
            Debug.LogError("GameClearUi �������� �ε��� �� �����ϴ�!");
        }
    }

    public void CloseSelectUI()
    {
        // Implement logic to close the SelectUi prefab if needed
    }
}

























































































