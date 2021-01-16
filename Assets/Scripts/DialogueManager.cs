using System.Collections;
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
    private Queue<Sprite> icons;

    void Start()
    {
        sentences = new Queue<string>();
        icons = new Queue<Sprite>();
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

        foreach (Sprite icon in dialogue.icon)
        {
            icons.Enqueue(icon);
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

        if(icons.Count > 0)
        {
            Sprite icon = icons.Dequeue();
            speaker.sprite = icon;
        }
        else
        {
            speaker.sprite = null;
        }
    }
}
