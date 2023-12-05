using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
[System.Serializable]
public class CutSceneClip 
{
    public string speaker;
    public string text;
    public string animationName = "";
    public AudioClip audioClip; // 오디오 클립 추가
}
