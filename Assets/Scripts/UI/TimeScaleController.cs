using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class TimeScaleController : MonoBehaviour
{
    private int speedIndex = 0;
    private float[] speeds = { 1.0f, 2.0f, 4.0f };
    private float originalTimeScale = 1.0f;

    public Dictionary<float, Sprite> speedImageMap;
    public Image speedImage;

    private void Start()
    {
        originalTimeScale = Time.timeScale;
        SceneManager.sceneLoaded += OnSceneLoaded;
        InitializeSpeedImageMap();
    }

    private void InitializeSpeedImageMap()
    {
        speedImageMap = new Dictionary<float, Sprite>();

        // Resources ���� ���� image/ui �������� �̹��� �ε�
        Sprite speed1x = Resources.Load<Sprite>("image/ui/1x"); // image/ui/1x.png ����
        Sprite speed2x = Resources.Load<Sprite>("image/ui/2x"); // image/ui/2x.png ����
        Sprite speed4x = Resources.Load<Sprite>("image/ui/4x"); // image/ui/4x.png ����

        speedImageMap.Add(1.0f, speed1x);
        speedImageMap.Add(2.0f, speed2x);
        speedImageMap.Add(4.0f, speed4x);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetTimeScale();
        UpdateSpeedImage();
    }

    public void ToggleTimeScale()
    {
        speedIndex = (speedIndex + 1) % speeds.Length;
        Time.timeScale = speeds[speedIndex];
        UpdateSpeedImage();
    }

    public void ResetTimeScale()
    {
        Time.timeScale = originalTimeScale;
        UpdateSpeedImage();
    }

    private void UpdateSpeedImage()
    {
        if (speedImageMap.ContainsKey(Time.timeScale))
        {
            speedImage.sprite = speedImageMap[Time.timeScale];
        }
        else
        {
            // ó���� ���� �߰�
        }
    }
}

