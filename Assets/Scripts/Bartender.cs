using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bartender : MonoBehaviour
{
    public Dialogue bartenderDialogueOther;
    public Dialogue bartenderDialogueIsis;
    public GameObject bartenderPanel;

    void Start()
    {
        bartenderPanel.SetActive(false);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(PlayerControl.instance.currentPlayer.GetComponent<Character2Skills>())
            {
                FindObjectOfType<DialogueManager>().StartDialogue(bartenderDialogueIsis, bartenderPanel);
            } else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(bartenderDialogueOther, bartenderPanel);
            }
            
        }
    }
}
