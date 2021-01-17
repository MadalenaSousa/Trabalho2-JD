using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Guardian : MonoBehaviour
{
    public Dialogue dialogueOther;
    public Dialogue dialogueSolution;
    public GameObject itemGameObject;
    Item itemToProtect;


    private void Start()
    {
        itemToProtect = itemGameObject.GetComponent<ItemPickup>().item;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(PlayerControl.instance.currentPlayer.bestSkill == itemToProtect.solutionSkill)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogueSolution);
                itemToProtect.canPickup = true;
            } else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogueOther);
            }
            
        }
    }
}
