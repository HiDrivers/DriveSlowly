using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour
{
    public TextMeshProUGUI talkText;
    public TextMeshProUGUI characterNameText;
    public string writerText = "";
    public Animator animator;
    public CutScneneSO cutScneneSO;
    private int currentCutSceneIndex = 0;
    public SoundManager soundManager; // 이 부분에 SoundManager 참조를 추가합니다.

    void Start()
    {
        ShowNextDialogue();
    }

    void ShowNextDialogue()
    {
        if (cutScneneSO == null)
            return;

        if (currentCutSceneIndex < cutScneneSO.cutSceneClips.Count)
        {
            CutSceneClip cutSceneClip = cutScneneSO.cutSceneClips[currentCutSceneIndex];

            // SoundManager 참조를 CutSceneClip에 할당합니다.
            cutSceneClip.soundManager = soundManager;

            StartCoroutine(EnterText(cutSceneClip));
            currentCutSceneIndex++;
        }
        else
        {
            Debug.Log("대화가 모두 종료되었습니다.");
            GameManager.Instance.LoadNextScene();
        }
    }

    IEnumerator NormalChat(CutSceneClip cutSceneClip)
    {
        characterNameText.text = cutSceneClip.speaker;
        writerText = "";

        animator.StopPlayback();

        if (!string.IsNullOrEmpty(cutSceneClip.animationName))
        {
            animator.Play(cutSceneClip.animationName);
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (cutSceneClip.audioClip != null)
        {
            float masterVolume = SoundManager.Instance.masterVolumeSlider.value;
            float effectVolume = SoundManager.Instance.effectVolumeSlider.value;
            audioSource.volume = masterVolume * effectVolume;

            audioSource.clip = cutSceneClip.audioClip;
            audioSource.Play();
        }

        for (int i = 0; i < cutSceneClip.text.Length; i++)
        {
            writerText += cutSceneClip.text[i];
            talkText.text = writerText;
            yield return new WaitForSeconds(0.05f);
        }

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        audioSource.Stop();

        ShowNextDialogue();
    }

    IEnumerator EnterText(CutSceneClip cutSceneClip)
    {
        yield return StartCoroutine(NormalChat(cutSceneClip));
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}


