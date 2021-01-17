using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenSphinx : MonoBehaviour
{
    public Dialogue dialogue;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
