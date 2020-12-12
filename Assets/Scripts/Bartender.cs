using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bartender : MonoBehaviour
{
    public Dialogue bartenderDialogue;
    public GameObject bartenderPanel;

    void Start()
    {
        bartenderPanel.SetActive(false);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(bartenderDialogue, bartenderPanel);
        }
    }
}
