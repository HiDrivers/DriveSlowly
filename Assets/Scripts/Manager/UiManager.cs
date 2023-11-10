using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    private Dictionary<string, GameObject> uiPrefabs = new Dictionary<string, GameObject>();

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

    public void LoadUIPrefabs()
    {
        var objs = Resources.LoadAll<GameObject>("Prefabs/UI/");
        foreach (var obj in objs)
        {
            string uiName = obj.name.ToLower();
            uiPrefabs[uiName] = obj;
        }
    }

    void Start()
    {
        LoadUIPrefabs();

        // "SettingUi" 테스트용 코드
        ShowSettingUi();

        // "SelectUi" 테스트용 코드
        Invoke("ShowSelectUi", 5f);

        // "GameClearUi" 테스트용 코드
        Invoke("ShowGameClearUi", 10f);
    }

    private void ShowSettingUi()
    {
        ShowUI<UIBase>("SettingUi", transform);
    }

    private void ShowSelectUi()
    {
        ShowUI<UIBase>("SelectUi", transform);
    }

    private void ShowGameClearUi()
    {
        ShowUI<UIBase>("GameClearUi", transform);
    }

    public T ShowUI<T>(string uiName, Transform parent) where T : UIBase
    {
        uiName = uiName.ToLower();

        if (uiPrefabs.ContainsKey(uiName))
        {
            GameObject uiGameObject = Instantiate(uiPrefabs[uiName], parent,true);
            T uiComponent = uiGameObject.GetComponent<T>();

            if (uiComponent != null)
            {
                return uiComponent;
            }
            else
            {
                Debug.LogError($"UI Component not found in UI Prefab: {uiName}");
                Destroy(uiGameObject);
            }
        }
        else
        {
            Debug.LogError($"UI Prefab not loaded: {uiName}");
        }

        return null;
    }
}













































































































