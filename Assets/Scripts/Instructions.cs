using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public Dialogue instruction;
    bool hasBeenInstructed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!GameManager.instance.hasAllAnswers)
        {
            if (!hasBeenInstructed)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(instruction);
                hasBeenInstructed = true;
            }
        }
    }
}
