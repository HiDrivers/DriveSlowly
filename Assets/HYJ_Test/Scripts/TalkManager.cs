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

    private bool isTyping = false;

    public CutScneneSO cutScneneSO;

    private int currentCutSceneIndex = 0;

    //private Queue<CutSceneClip> dialogueQueue = new Queue<CutSceneClip>();


    //public struct Dialogue
    //{
    //    public string speaker;
    //    public string text;
    //}

    void Start()
    {
        ShowNextDialogue();
    }

    void CutScene() 
    {
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "알람", text = "RRRRRRRR(일.어.나)" });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "Zzzzz..쿠-울..."  , animationName = "Dialogue1_2" });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "음.. 졸려.. 지금 몇시지?" , animationName = "Dialogue1_3" });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "!!!! 8시 40분?!" ,animationName = "Dialogue1_4" });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "안돼 9시까지 출근 해야 하는데 지각이다", animationName = "Dialogue1_5" });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "이번에도 지각하면 정직원 전환은 ...\n진짜 끝이야", animationName = "Dialogue1_6" });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "......어떻게 하지?", animationName = "Dialogue1_7" });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "......", animationName = "Dialogue1_8" });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "과속하면 벌금이...", animationName = "Dialogue1_9" });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "......" });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "...그렇지만 오늘이 정직원이 될 마지막 기회인데",animationName = "Dialogue1_11" });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "......그래 지금 벌금이 문제가 아니야..." });
        //dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "최대한 밟는거야! 할 수 있다 천천희! 제발 정직원 가즈아~" , animationName = "Dialogue1_13" });
    }

 

    void ShowNextDialogue()
    {

        if (cutScneneSO == null)
            return;

        if (currentCutSceneIndex < cutScneneSO.cutSceneClips.Count)
        {
            CutSceneClip cutSceneClip = cutScneneSO.cutSceneClips[currentCutSceneIndex];
            StartCoroutine(EnterText(cutSceneClip));

            // 대화가 시작될 때마다 인덱스를 증가시켜 다음 대화 클립을 가리킵니다.
            currentCutSceneIndex++;
        }
        else
        {
            // 대화가 모두 종료되었을 때 할 일을 여기에 추가할 수 있습니다.
            Debug.Log("대화가 모두 종료되었습니다.");
        }
    }
    //string currentSceneName = SceneManager.GetActiveScene().name;

    //if (cutScneneSO == null)
    //    return;

    //if (cutScneneSO.cutSceneClips.Count > 0)
    //{
    //    CutSceneClip cutSceneClip = cutScneneSO.cutSceneClips[0];
    //    cutScneneSO.cutSceneClips.RemoveAt(0);
    //    StartCoroutine(EnterText(cutSceneClip));
    //}


    //else
    //{
    //    if (currentSceneName == "HYJ_TestScene")
    //    {
    //        StartCoroutine(LoadSceneAfterDelay("HYJ_TestScene2", 2.0f));
    //    } 
    //    else if (currentSceneName == "HYJ_TestScene2")
    //    {
    //        StartCoroutine(LoadSceneAfterDelay("SampleScene", 2.0f));
    //    }
    //}


    IEnumerator NormalChat(CutSceneClip cutSceneClip)
    {
        isTyping = true;
        characterNameText.text = cutSceneClip.speaker;
        writerText = "";
        // 애니매이션 실행
        if (cutSceneClip.animationName != null)
        {
            animator.Play(cutSceneClip.animationName);
        }
        
        
        for (int i = 0; i < cutSceneClip.text.Length; i++)
        {
            writerText +=cutSceneClip.text[i];
            talkText.text = writerText;
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;

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
