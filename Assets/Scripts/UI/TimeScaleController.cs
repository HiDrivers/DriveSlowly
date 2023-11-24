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
        SceneManager.sceneLoaded += OnSceneLoaded; // ���� �ε�� ������ ȣ��Ǵ� �̺�Ʈ �߰�
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetTimeScale(); // ���� �ε�� ������ ����� �ʱ�ȭ
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

