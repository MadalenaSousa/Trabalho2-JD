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

    void Start()
    {
        inventory = Inventory.instance;
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
                        break;
                    }
                    else
                    {
                        Debug.Log("No Solution and Inventory not empty");
                        FindObjectOfType<DialogueManager>().StartDialogue(sphinxDialogueUnsolved);
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
