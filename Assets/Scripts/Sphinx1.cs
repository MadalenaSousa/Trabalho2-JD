using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphinx1 : MonoBehaviour
{
    public GameObject firstEnigmaPanel;

    void Start()
    {
        firstEnigmaPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstEnigmaPanel.SetActive(true);
        }
    }

    public void closePanel()
    {
        firstEnigmaPanel.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Door1")); //This is not here, this is in a function triggered by solving the first enigma, this is only for demonstrantion purpuses
    }
}
