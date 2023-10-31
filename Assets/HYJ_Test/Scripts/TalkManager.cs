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
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "!!!! 8시 40분?!\n 안돼 9시까지 출근 해야 하는데 지각이다" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "이번에도 지각하면 정직원 전환은 ...진짜 끝이야" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "..." });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "..." });
        dialogueQueue.Enqueue(new Dialogue { speaker = "주인공", text = "벌금이 문제가 아니야... 밟아 OOO 제발 정직원 가즈아" });


    }

    void CutScene2()
    {
        dialogueQueue.Clear();

        dialogueQueue.Enqueue(new Dialogue { speaker = "Joo", text = "OMG i need a HanguelFont " });
        dialogueQueue.Enqueue(new Dialogue { speaker = "haha", text = "This is Test" });
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

        yield return new WaitForSeconds(0.5f);

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
