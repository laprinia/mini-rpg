using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private String button1Text;
    private String button2Text;
    public Button firstButton;
    public Button secondButton;
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

    public Button getFirstButton()
    {
        return firstButton;
    }

    public Button getSecondButton()
    {
        return secondButton;
    }
    public void StartDialogue(Dialogue dialogue,String button1Text,String button2Text)
    {
        this.button1Text = button1Text;
        this.button2Text = button2Text;
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
        if (sentences.Count == 1)
        {
            if (button1Text != null)
            {
                firstButton.GetComponentInChildren<TextMeshProUGUI>().text = button1Text; 
            }
            else
            {
                firstButton.gameObject.SetActive(false);
            }

            if (button2Text != null)
            {
                secondButton.GetComponentInChildren<TextMeshProUGUI>().text = button2Text;
            }
            else
            {
                secondButton.gameObject.SetActive(false);
            }
        }
        else if (sentences.Count == 0)
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
