using UnityEngine;
using System.Collections.Generic;

public class UIManager : Singleton<UIManager>
{
    private Dictionary<string, GameObject> uiPrefabs = new Dictionary<string, GameObject>();

    void Start()
    {
        LoadUIPrefabs();
    }

    public void LoadUIPrefabs()
    {
        var objs = Resources.LoadAll<GameObject>("Prefabs/UI");
        foreach (var obj in objs)
        {
            string uiName = obj.name;
            uiPrefabs[uiName] = obj;
        }
    }

    public T ShowUI<T>(string uiName, Transform parent) where T : UIBase
    {
        if (uiPrefabs.TryGetValue(uiName, out GameObject prefab))
        {
            T existingUI = parent.GetComponentInChildren<T>();
            if (existingUI != null)
            {
                return existingUI;
            }
            else
            {
                GameObject uiGameObject = Instantiate(prefab, parent, false);
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
        }
        else
        {
            Debug.LogError($"UI Prefab not loaded: {uiName}");
        }

        return null;
    }
}



























































































































