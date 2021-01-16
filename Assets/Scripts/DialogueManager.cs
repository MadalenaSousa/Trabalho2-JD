﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialoguePanel;
    public Image speaker;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialoguePanel.SetActive(true);
        Time.timeScale = 0;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            dialoguePanel.SetActive(false);
            Time.timeScale = 1;
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
}
