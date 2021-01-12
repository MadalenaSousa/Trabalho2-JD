using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphinx : MonoBehaviour
{
    public Dialogue sphinxDialogueUnsolved;
    public Dialogue sphinxDialogueSolved;
    Inventory inventory;
    public Item solutionItem;
    bool solved;

    void Start()
    {
        inventory = Inventory.instance;
        solved = false;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
            if(inventory.items.Count > 0)
            {
                for (int i = 0; i < inventory.items.Count; i++)
                {
                    Debug.Log("looping");
                    if (inventory.items[i].name == solutionItem.name)
                    {
                        Debug.Log("Found Solution");
                        FindObjectOfType<DialogueManager>().StartDialogue(sphinxDialogueSolved);
                        GameManager.instance.answers[solutionItem.name] = true;
                        inventory.RemoveItem(inventory.items[i]);
                        solved = true;
                        break;
                    }
                    else
                    {
                        if(solved)
                        {
                            Debug.Log("No Solution and Inventory not empty");
                            FindObjectOfType<DialogueManager>().StartDialogue(sphinxDialogueSolved);
                        } else
                        {
                            Debug.Log("No Solution and Inventory not empty");
                            FindObjectOfType<DialogueManager>().StartDialogue(sphinxDialogueUnsolved);
                        }
                    }
                }
            }
            else
            {
                Debug.Log("No Solution and Empty Inventory");
                FindObjectOfType<DialogueManager>().StartDialogue(sphinxDialogueUnsolved);
            }
        }
    }
}
