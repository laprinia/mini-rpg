using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogCanvas;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public static DialogueManager instance;
    private Queue<string> sentences;

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        sentences=new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogCanvas.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (var sentence in dialogue.sentences)
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

        dialogueText.text = sentences.Dequeue();
    }

    public void EndDialogue()
    {
        dialogCanvas.SetActive(false);
    }
}
