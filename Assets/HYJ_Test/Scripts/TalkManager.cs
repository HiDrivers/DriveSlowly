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

    private Queue<CutSceneClip> dialogueQueue = new Queue<CutSceneClip>();


    //public struct Dialogue
    //{
    //    public string speaker;
    //    public string text;
    //}

    void Start()
    {
        //string currentSceneName = SceneManager.GetActiveScene().name;


        //if (currentSceneName == "HYJ_TestScene")
        //{
        //    CutScene1();
        //}
        //else if (currentSceneName == "HYJ_TestScene2")
        //{
        //    CutScene2();
        //}
        CutScene();

        ShowNextDialogue();
    }

    void CutScene() 
    {
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "알람", text = "RRRRRRRR(일.어.나)" });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "Zzzzz..쿠-울..."  , animationName = "Dialogue1_2" });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "음.. 졸려.. 지금 몇시지?" , animationName = "Dialogue1_3" });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "!!!! 8시 40분?!" ,animationName = "Dialogue1_4" });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "안돼 9시까지 출근 해야 하는데 지각이다", animationName = "Dialogue1_5" });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "이번에도 지각하면 정직원 전환은 ...\n진짜 끝이야", animationName = "Dialogue1_6" });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "......어떻게 하지?" });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "......" });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "과속하면 벌금이..." });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "......" });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "...그렇지만 오늘이 정직원이 될 마지막 기회인데" });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "......그래 지금 벌금이 문제가 아니야..." });
        dialogueQueue.Enqueue(new CutSceneClip { speaker = "천천희", text = "최대한 밟는거야! 할 수 있다 천천희! 제발 정직원 가즈아~" });
    }

 

    //void CutScene2()
    //{
    //    dialogueQueue.Clear();

    //    dialogueQueue.Enqueue(new Dialogue { speaker = "부장님", text = "OO씨 점심 먹고 오후에 A 회사에서 하는 미팅 잊은 건 아니겠지?" });
    //    dialogueQueue.Enqueue(new Dialogue { speaker = "부장님", text = "오늘 자네의 발표에 회사의 미래가 걸려 있어!" });
    //    dialogueQueue.Enqueue(new Dialogue { speaker = "부장님", text = "자네 눈이 좋은 사슴을 뭐라고 하는 줄 아나?" });
    //    dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "죄송합니다. 잘 모르겠습니다." });
    //    dialogueQueue.Enqueue(new Dialogue { speaker = "부장님", text = "눈이 좋은 사슴은 바로 굿 아이디어라네 ^^ 하하하" });
    //    dialogueQueue.Enqueue(new Dialogue { speaker = "부장님", text = "자네의 굿 아이디어 기대하겠네!" });
    //    dialogueQueue.Enqueue(new Dialogue { speaker = "부장님", text = "자 다들 밥 먹으러 가자고~ 하하하" });
    //    dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "(아 부장님의 개그 너무 피곤해..\n게다가 밥 먹고 바로 운전하면 너무 졸릴 텐데… 이번 미팅 어쩌지?)" });

    //}

    void ShowNextDialogue()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (dialogueQueue.Count > 0)
        {
            CutSceneClip cutSceneClip = dialogueQueue.Dequeue();
            StartCoroutine(EnterText(cutSceneClip));
        }
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
    }

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
