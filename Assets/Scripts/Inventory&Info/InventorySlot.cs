using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text itemName;
    Item item;

    public void addItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        itemName.text = item.name;
        icon.enabled = true;
    }

    public void clearSlot()
    {
        item = null;

        icon.sprite = null;
        itemName.text = null;
        icon.enabled = false;
    }
}
