using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTabs : MonoBehaviour
{
    public GameObject inventoryPanel, characterInfoPanel, infoMenu;
    public Sprite chestClosed;
    public Sprite chestOpen;

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
            GetComponent<Image>().sprite = chestClosed;
            infoMenu.SetActive(false);
            inventoryPanel.SetActive(false);
            characterInfoPanel.SetActive(false);
        } else
        {
            GetComponent<Image>().sprite = chestOpen;
            infoMenu.SetActive(true);
            inventoryPanel.SetActive(true);
            characterInfoPanel.SetActive(false);
        }
        
    }
}
