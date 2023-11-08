//using UnityEngine;
//using System.Collections.Generic;
//using UnityEngine.UI;
//using TMPro;

//public class UIManager : MonoBehaviour
//{
//    private static UIManager instance;

//    public static UIManager Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = FindObjectOfType<UIManager>();
//                if (instance == null)
//                {
//                    GameObject obj = new GameObject("UIManager");
//                    instance = obj.AddComponent<UIManager>();
//                }
//            }
//            return instance;
//        }
//    }

//    private Dictionary<string, GameObject> uiPrefabs = new Dictionary<string, GameObject>();

//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }

//    public GameObject LoadUIPrefab(string prefabName)
//    {
//        GameObject prefab = Resources.Load<GameObject>("UIPrefabs/" + prefabName);
//        if (prefab != null)
//        {
//            return prefab;
//        }
//        else
//        {
//            Debug.LogWarning("UIPrefab not found: " + prefabName);
//            return null;
//        }
//    }

//    public T ShowUI<T>(string uiName) where T : MonoBehaviour
//    {
//        GameObject uiPrefab = LoadUIPrefab(uiName);
//        if (uiPrefab != null)
//        {
//            GameObject uiInstance = Instantiate(uiPrefab);
//            T uiComponent = uiInstance.GetComponent<T>();
//            return uiComponent;
//        }
//        else
//        {
//            Debug.LogWarning("UI not found: " + uiName);
//            return null;
//        }
//    }
//}

//public class StartScene : MonoBehaviour
//{
//    public void Initialize()
//    {
//        // StartScene �ʱ�ȭ �ڵ� �߰�
//    }

//    public void StartGame()
//    {
//        // ���� ���� ���� �߰�
//    }
//}

//public class LobbyScene : MonoBehaviour
//{
//    public Slider gameTimerSlider;

//    public void Initialize()
//    {
//        // LobbyScene �ʱ�ȭ �ڵ� �߰�
//    }

//    // lobbyscene���� carselcect �˾��� ��� �� �ִ� ��ư
//    public void ShowCarSelectPopup()
//    {
//        UIManager.Instance.ShowUI<CarSelectPopup>("CarSelectPopup").Initialize();
//    }

//    // lobbyscene���� mainscene ���� ���� ��ư
//    public void GoToMainScene()
//    {
//        UIManager.Instance.ShowUI<MainScene>("MainScene").Initialize();
//    }

//    // lobbyscene���� settingscene ���� ���� ��ư
//    public void GoToSettingScene()
//    {
//        UIManager.Instance.ShowUI<SettingScene>("SettingScene").Initialize();
//    }

//    // lobbyscene���� endinglist �˾��� ����ִ� ��ư
//    public void ShowEndingListPopup()
//    {
//        UIManager.Instance.ShowUI<EndingListPopup>("EndingListPopup").Initialize();
//    }
//}

//public class CarSelectPopup : MonoBehaviour
//{
//    public void Initialize()
//    {
//        // CarSelectPopup �ʱ�ȭ �ڵ� �߰�
//    }

//    // carselect �˾� ���� car(player)�� ��ü���ټ��ִ� ��ư��(6���̻� ���� ���� ���� �̿Ϸ� �ּ�ó��)
//    public void SelectCar(int carIndex)
//    {
//        // ���� ���� ���� �߰�
//    }
//}

//public class MainScene : MonoBehaviour
//{
//    public Slider gameTimerSlider; // 'gameTimerSlider' ���� �߰�
//    public TMP_Text goldText;
//    public TMP_Text durabilityText;

//    public void Initialize()
//    {
//        // MainScene �ʱ�ȭ �ڵ� �߰�
//    }

//    // mainscene ���� pause �˾� ����ִ� ��ư(���� �Ͻ�����)
//    public void PauseGame()
//    {
//        UIManager.Instance.ShowUI<PausePopup>("PausePopup").Initialize();
//    }

//    // mainscene ���� 90�ʰ� ������ ���� Ŭ���� ���ִ� �����̴�
//    public void UpdateGameClearSlider(float value)
//    {
//        if (gameTimerSlider != null)
//        {
//            gameTimerSlider.value = value;
//        }
//    }

//    // mainscene ���� ��� �������� ������ ��尡 ����ϴ� text mesh pro
//    public void UpdateGoldText(string value)
//    {
//        if (goldText != null)
//        {
//            goldText.text = value;
//        }
//    }

//    // mainscene ���� ��ֹ��� �ε������ �������� �������� �������� 0�̵Ǹ� ���ӿ����Ǵ� text mesh pro
//    public void UpdateDurabilityText(string value)
//    {
//        if (durabilityText != null)
//        {
//            durabilityText.text = value;
//        }
//    }
//}

//public class SettingScene : MonoBehaviour
//{
//    public void Initialize()
//    {
//        // SettingScene �ʱ�ȭ �ڵ� �߰�
//    }
//}

//public class EndingListPopup : MonoBehaviour
//{
//    public void Initialize()
//    {
//        // EndingListPopup �ʱ�ȭ �ڵ� �߰�
//    }

//    // endinglist �˾����� ���� ��ư��(6���̻�) ������ ���� �ƾ� �����ִ� ��ư (���� �̿Ϸ� �ּ�ó��)
//    public void ShowEndingCutscene(int endingIndex)
//    {
//        // ���� �ƾ� ���� �߰�
//    }
//}

//public class PausePopup : MonoBehaviour
//{
//    public void Initialize()
//    {
//        // PausePopup �ʱ�ȭ �ڵ� �߰�
//    }

//    // pause �˾����� ������ ����� ���ִ� ��ư
//    public void RestartGame()
//    {
//        // ���� ����� ���� �߰�
//    }

//    // pause �˾����� setting ������ ���¹�ư
//    public void GoToSettingScene()
//    {
//        UIManager.Instance.ShowUI<SettingScene>("SettingScene").Initialize();
//    }

//    // pause �˾����� ������ �簳���ִ� ��ư
//    public void ResumeGame()
//    {
//        // ���� �簳 ���� �߰�
//    }
//}

//// �ʿ��Ѱ��� �������� �ִ°� �׷� ���������̳� ���������� ������Ҷ� "�ٽ� ex) animation ��ȭâ ������ 2�� 1�� ui�Ŵ��� show ui �̴ϼȶ����� ���ϴ� ui�� ���� �̹� ���� �����ϴ� ui�� �ʿ���������"
//// ��Ȳ��Ȳ�� �ʿ��� ui�� ������Ҷ� ��ũ��Ʈ�� �ҷ����� ��������
//// ui�� ��������� ���ϰ� ��ﶧ ���� ���Ǽ� �� ���� �������ִ� ������ ui���� �ʿ�X
//// UI�Ŵ����� Ȱ���ؼ� ���� ���� [ EX) UI���� ��ư�� �������� UI����â�� ����ִ� var ui = UIManager.ShowUI<OptionUI>(); ui.Initialize(); ]
//// �ʿ��� UI�� �׶� �׶� ����
////  EX)�̿��� �������� �����ִ� â�� ���� ��ȭ �߰� ������ â�� ����