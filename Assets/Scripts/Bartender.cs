using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bartender : MonoBehaviour
{
    public Dialogue bartenderDialogueOther;
    public Dialogue bartenderDialogueIsis;
    public Text bartenderText;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(PlayerControl.instance.currentPlayer.GetComponent<Isis>())
            {
                FindObjectOfType<DialogueManager>().StartDialogue(bartenderDialogueIsis);
            } else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(bartenderDialogueOther);
            }
            
        }
    }
}
