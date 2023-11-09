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
//        // StartScene 초기화 코드 추가
//    }

//    public void StartGame()
//    {
//        // 게임 시작 로직 추가
//    }
//}

//public class LobbyScene : MonoBehaviour
//{
//    public Slider gameTimerSlider;

//    public void Initialize()
//    {
//        // LobbyScene 초기화 코드 추가
//    }

//    // lobbyscene에서 carselcect 팝업을 띄울 수 있는 버튼
//    public void ShowCarSelectPopup()
//    {
//        UIManager.Instance.ShowUI<CarSelectPopup>("CarSelectPopup").Initialize();
//    }

//    // lobbyscene에서 mainscene 으로 가는 버튼
//    public void GoToMainScene()
//    {
//        UIManager.Instance.ShowUI<MainScene>("MainScene").Initialize();
//    }

//    // lobbyscene에서 settingscene 으로 가는 버튼
//    public void GoToSettingScene()
//    {
//        UIManager.Instance.ShowUI<SettingScene>("SettingScene").Initialize();
//    }

//    // lobbyscene에서 endinglist 팝업을 띄워주는 버튼
//    public void ShowEndingListPopup()
//    {
//        UIManager.Instance.ShowUI<EndingListPopup>("EndingListPopup").Initialize();
//    }
//}

//public class CarSelectPopup : MonoBehaviour
//{
//    public void Initialize()
//    {
//        // CarSelectPopup 초기화 코드 추가
//    }

//    // carselect 팝업 에서 car(player)를 교체해줄수있는 버튼들(6개이상 아직 차량 구현 미완료 주석처리)
//    public void SelectCar(int carIndex)
//    {
//        // 차량 선택 로직 추가
//    }
//}

//public class MainScene : MonoBehaviour
//{
//    public Slider gameTimerSlider; // 'gameTimerSlider' 변수 추가
//    public TMP_Text goldText;
//    public TMP_Text durabilityText;

//    public void Initialize()
//    {
//        // MainScene 초기화 코드 추가
//    }

//    // mainscene 에서 pause 팝업 띄워주는 버튼(게임 일시정지)
//    public void PauseGame()
//    {
//        UIManager.Instance.ShowUI<PausePopup>("PausePopup").Initialize();
//    }

//    // mainscene 에서 90초가 지나면 게임 클리어 해주는 슬라이더
//    public void UpdateGameClearSlider(float value)
//    {
//        if (gameTimerSlider != null)
//        {
//            gameTimerSlider.value = value;
//        }
//    }

//    // mainscene 에서 골드 아이템을 먹을시 골드가 상승하는 text mesh pro
//    public void UpdateGoldText(string value)
//    {
//        if (goldText != null)
//        {
//            goldText.text = value;
//        }
//    }

//    // mainscene 에서 장애물에 부딪힐경우 내구도가 떨어져서 내구도가 0이되면 게임오버되는 text mesh pro
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
//        // SettingScene 초기화 코드 추가
//    }
//}

//public class EndingListPopup : MonoBehaviour
//{
//    public void Initialize()
//    {
//        // EndingListPopup 초기화 코드 추가
//    }

//    // endinglist 팝업에서 엔딩 버튼들(6개이상) 누를시 엔딩 컷씬 보여주는 버튼 (아직 미완료 주서처리)
//    public void ShowEndingCutscene(int endingIndex)
//    {
//        // 엔딩 컷씬 로직 추가
//    }
//}

//public class PausePopup : MonoBehaviour
//{
//    public void Initialize()
//    {
//        // PausePopup 초기화 코드 추가
//    }

//    // pause 팝업에서 게임을 재시작 해주는 버튼
//    public void RestartGame()
//    {
//        // 게임 재시작 로직 추가
//    }

//    // pause 팝업에서 setting 씬으로 가는버튼
//    public void GoToSettingScene()
//    {
//        UIManager.Instance.ShowUI<SettingScene>("SettingScene").Initialize();
//    }

//    // pause 팝업에서 게임을 재개해주는 버튼
//    public void ResumeGame()
//    {
//        // 게임 재개 로직 추가
//    }
//}

//// 필요한것은 선택지를 주는것 그런 선택지들이나 선택지들을 띄워야할때 "핵심 ex) animation 대화창 선택지 2중 1택 ui매니저 show ui 이니셜라이즈 원하는 ui를 띄우는 이미 씬에 존재하는 ui는 필요하지않음"
//// 상황상황에 필요한 ui를 띄워야할때 스크립트로 불러오는 방향으로
//// ui를 띄우고싶을때 편하게 띄울때 띄우는 편의성 씬 내에 넣을수있는 간단한 ui들은 필요X
//// UI매니저를 활용해서 만든 느낌 [ EX) UI설정 버튼을 눌럿을때 UI설정창을 띄워주는 var ui = UIManager.ShowUI<OptionUI>(); ui.Initialize(); ]
//// 필요한 UI를 그때 그때 띄우는
////  EX)미연시 선택지를 고를수있는 창을 띄우는 대화 중간 선택지 창을 띄우는