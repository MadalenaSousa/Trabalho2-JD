using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Picking up " + item.name);
            Inventory.instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}
