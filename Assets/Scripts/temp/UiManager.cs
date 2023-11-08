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
            Debug.Log($"{uiName}(Prefabs/UI/{obj.name}) is loaded.");
        }
    }

    public T ShowUI<T>(string uiName, Transform parent) where T : UIBase
    {
        
        uiName = uiName.ToLower();

        if (uiPrefabs.ContainsKey(uiName))
        {
            GameObject uiGameObject = Instantiate(uiPrefabs[uiName], parent);
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

    void Start()
    {
        LoadUIPrefabs();

        // 5초 후에 'select1' 프리팹을 표시
        Invoke("ShowSelect1", 5f);

        // 5초 후에 'select2' 프리팹을 표시
        Invoke("ShowSelect2", 5f);
    }

    private void ShowSelect1()
    {
        ShowUI<UIBase>("select1", transform);
    }

    private void ShowSelect2()
    {
        ShowUI<UIBase>("select2", transform);
    }
}
