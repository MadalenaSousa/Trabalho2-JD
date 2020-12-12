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
    }
}
