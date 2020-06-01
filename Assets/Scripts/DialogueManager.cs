using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Types;

public class DialogueManager : Singleton<DialogueManager>
{
    private Queue<string> sentences;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public bool isEnding = false;
    public DialogueType currentDialogueType;

    protected override void Awake()
    {
        base.Awake();
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogueType = dialogue.type;
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        if (currentDialogueType == DialogueType.Change)
        {
            SoundManager.Instance.PlayMusic(SoundManager.Instance.supriseMusic);
            Boss.Instance.anim.SetTrigger("Change");
            Boss.Instance.StartDialog2();
        }
        else if (currentDialogueType == DialogueType.Ending)
        {
            GameManager.Instance.Quit();
        }
        else if(currentDialogueType == DialogueType.Start)
        {
            GameManager.Instance.LoadScene("Game");
        }
    }
}
