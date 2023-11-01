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

    private bool isTyping = false;
    private Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();


    public struct Dialogue
    {
        public string speaker;
        public string text;
    }

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

   
        if (currentSceneName == "HYJ_TestScene")
        {
            CutScene1();
        }
        else if (currentSceneName == "HYJ_TestScene2")
        {
            CutScene2();
        }

        ShowNextDialogue();
    }

    void CutScene1()
    {
        dialogueQueue.Clear(); // 이전 대사를 비우고 새로운 대사를 설정

        dialogueQueue.Enqueue(new Dialogue { speaker = "알람시계", text = "RRRRRRRR(일.어.나)" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "Zzzzz..쿠-울..." });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "음.. 졸려.. 지금 몇시지?" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "!!!! 8시 40분?!\n안돼 9시까지 출근 해야 하는데 지각이다" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "이번에도 지각하면 정직원 전환은 ...\n진짜 끝이야" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "......어떻게 하지?" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "......" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "과속하면 벌금이..." });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "......" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "...그렇지만 오늘이 정직원이 될 마지막 기회인데" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "......그래" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "벌금이 문제가 아니야...\n밟자! OOO! 제발 정직원 가즈아" });


    }

    void CutScene2()
    {
        dialogueQueue.Clear();

        dialogueQueue.Enqueue(new Dialogue { speaker = "부장님", text = "OO씨 점심 먹고 오후에 A 회사에서 하는 미팅 잊은 건 아니겠지?" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "부장님", text = "오늘 자네의 발표에 회사의 미래가 걸려 있어!" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "부장님", text = "자네 눈이 좋은 사슴을 뭐라고 하는 줄 아나?" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "죄송합니다. 잘 모르겠습니다." });
        dialogueQueue.Enqueue(new Dialogue { speaker = "부장님", text = "눈이 좋은 사슴은 바로 굿 아이디어라네 ^^ 하하하" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "부장님", text = "자네의 굿 아이디어 기대하겠네!\n자 다들 밥 먹으러 가자고~ 하하" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "(아 부장님의 개그 너무 피곤해..\n게다가 밥 먹고 바로 운전하면 너무 졸릴 텐데… 이번 미팅 어쩌지?)" });

    }

    void ShowNextDialogue()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (dialogueQueue.Count > 0)
        {
            Dialogue dialogue = dialogueQueue.Dequeue();
            StartCoroutine(EnterText(dialogue.speaker, dialogue.text));
        }
        else
        {
            if (currentSceneName == "HYJ_TestScene")
            {
                StartCoroutine(LoadSceneAfterDelay("HYJ_TestScene2", 2.0f));
            } 
            else if (currentSceneName == "HYJ_TestScene2")
            {
                StartCoroutine(LoadSceneAfterDelay("SampleScene", 2.0f));
            }
        }
    }

    IEnumerator NormalChat(string speaker, string text)
    {
        isTyping = true;
        characterNameText.text = speaker;
        writerText = "";

        for (int i = 0; i < text.Length; i++)
        {
            writerText += text[i];
            talkText.text = writerText;
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;

        yield return new WaitForSeconds(0.5f); // 각 대사가 끝난 0.5초 뒤 다음대사가 자동으로 재생 

        ShowNextDialogue();
    }

    IEnumerator EnterText(string speaker, string text)
    {
        yield return StartCoroutine(NormalChat(speaker, text));
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        // 지정된 시간이 지난 후 다음 씬을 로드
        SceneManager.LoadScene(sceneName);
    }
}
