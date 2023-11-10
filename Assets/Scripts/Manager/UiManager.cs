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
            Debug.LogError("ProgressSlider를 찾을 수 없습니다! ProgressSlider를 Unity Editor에서 직접 할당하세요.");
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
                Debug.LogError("CloseSelect 버튼을 찾을 수 없습니다!");
            }
        }
        else
        {
            Debug.LogError("SelectUi 프리팹을 로드할 수 없습니다!");
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
            Debug.LogError("Setting 프리팹을 찾을 수 없습니다!");
        }

        gameClearUiPrefab = Resources.Load<GameObject>("Prefabs/Ui/GameClearUi");
        if (gameClearUiPrefab == null)
        {
            Debug.LogError("GameClearUi 프리팹을 찾을 수 없습니다!");
        }

        selectUiPrefab = Resources.Load<GameObject>("Prefabs/Ui/SelectUi");
        if (selectUiPrefab == null)
        {
            Debug.LogError("SelectUi 프리팹을 찾을 수 없습니다!");
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
                Debug.LogError("CloseSetting 버튼을 찾을 수 없습니다!");
            }
        }
        else
        {
            Debug.LogError("Setting 프리팹을 로드할 수 없습니다!");
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
            Debug.LogError("GameClearUi 프리팹을 로드할 수 없습니다!");
        }
    }

    public void CloseSelectUI()
    {
        // Implement logic to close the SelectUi prefab if needed
    }
}

























































































