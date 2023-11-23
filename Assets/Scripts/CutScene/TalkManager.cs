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

        // 애니매이션 실행
        if (!string.IsNullOrEmpty(cutSceneClip.animationName))
        {
            animator.Play(cutSceneClip.animationName);
        }


        for (int i = 0; i < cutSceneClip.text.Length; i++)
        {
            writerText +=cutSceneClip.text[i];
            talkText.text = writerText;
            yield return new WaitForSeconds(0.05f);
        }

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        ShowNextDialogue();
    }

    IEnumerator EnterText(CutSceneClip cutSceneClip)
    {
        yield return StartCoroutine(NormalChat(cutSceneClip));
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        // 지정된 시간이 지난 후 다음 씬을 로드
        SceneManager.LoadScene(sceneName);
    }
}
