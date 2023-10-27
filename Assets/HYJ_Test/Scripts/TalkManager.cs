using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        dialogueQueue.Enqueue(new Dialogue { speaker = "Ham", text = "Hello, how are you?" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "Young", text = "I'm good, thanks!" });
        dialogueQueue.Enqueue(new Dialogue { speaker = "Joo", text = "OMG i need a HanguelFont " });
        dialogueQueue.Enqueue(new Dialogue { speaker = "haha", text = "This is Test" });

        ShowNextDialogue();
    }

    void ShowNextDialogue()
    {
        if (dialogueQueue.Count > 0)
        {
            Dialogue dialogue = dialogueQueue.Dequeue();
            StartCoroutine(EnterText(dialogue.speaker, dialogue.text));
        }
        else
        {
            // 대화 종료 또는 다른 작업 수행
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

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        ShowNextDialogue();
    }

    IEnumerator EnterText(string speaker, string text)
    {
        yield return StartCoroutine(NormalChat(speaker, text));
    }
}
