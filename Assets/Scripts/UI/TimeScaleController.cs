using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeScaleController : MonoBehaviour
{
    private int speedIndex = 0;
    private float[] speeds = { 1.0f, 2.0f, 4.0f };
    private float originalTimeScale = 1.0f;

    private void Start()
    {
        originalTimeScale = Time.timeScale;
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬이 로드될 때마다 호출되는 이벤트 추가
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetTimeScale(); // 씬이 로드될 때마다 배속을 초기화
    }

    public void ToggleTimeScale()
    {
        speedIndex = (speedIndex + 1) % speeds.Length;
        Time.timeScale = speeds[speedIndex];
    }

    public void ResetTimeScale()
    {
        Time.timeScale = originalTimeScale;
    }
}

