using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTabs : MonoBehaviour
{
    public GameObject inventoryPanel, characterInfoPanel, infoMenu;

    private void Start()
    {
        infoMenu.SetActive(false);
        inventoryPanel.SetActive(false);
        characterInfoPanel.SetActive(false);
    }

    public void setInventoryPanelActive()
    {
        inventoryPanel.SetActive(true);
        characterInfoPanel.SetActive(false);
    }

    public void setCharacterInfoPanelActive()
    {
        characterInfoPanel.SetActive(true);
        inventoryPanel.SetActive(false);
    }

    public void switchInfoMenuState()
    {
        if(infoMenu.activeSelf)
        {
            GetComponentInChildren<Text>().text = "Info";
            infoMenu.SetActive(false);
            inventoryPanel.SetActive(false);
            characterInfoPanel.SetActive(false);
        } else
        {
            GetComponentInChildren<Text>().text = "Close";
            infoMenu.SetActive(true);
            inventoryPanel.SetActive(true);
            characterInfoPanel.SetActive(false);
        }
        
    }
}
