using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    Isis isis;
    Horus horus;
    Anubis anubis;

    private void Start()
    {
        isis = PlayerControl.instance.isis;
        horus = PlayerControl.instance.horus;
        anubis = PlayerControl.instance.anubis;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, gameObject.transform.position) < 10f)
            {
                Debug.Log("Picking up " + item.name);
                if (item.name == "ankh")
                {
                    if (isis.isDead)
                    {
                        Debug.Log("Isis is Dead");
                        isis.isDead = false;
                        isis.setHealth(isis.getMaxHealth());
                    }
                    else if (horus.isDead)
                    {
                        Debug.Log("Horus is Dead");
                        horus.isDead = false;
                        horus.setHealth(horus.getMaxHealth());
                    }
                    else if (anubis.isDead)
                    {
                        Debug.Log("Anubis is Dead");
                        anubis.isDead = false;
                        anubis.setHealth(anubis.getMaxHealth());
                    }
                    else
                    {
                        Inventory.instance.AddItem(item);
                    }
                }
                else
                {
                    Inventory.instance.AddItem(item);
                }
                Destroy(gameObject);
            }
            
        }
    }
}
