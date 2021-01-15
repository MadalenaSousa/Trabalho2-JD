using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    Isis isis;
    Horus horus;
    Anubis anubis;
    SpriteRenderer thisObjectSprite;

    private void Start()
    {
        isis = PlayerControl.instance.isis;
        horus = PlayerControl.instance.horus;
        anubis = PlayerControl.instance.anubis;

        thisObjectSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(GameManager.instance.checkPlayerProximityToObject(gameObject))
        {
            Debug.Log("SHINE OBJECT");
        }
        else
        {
            Debug.Log("DONT SHINE OBJECT");
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameManager.instance.checkPlayerProximityToObject(gameObject))
            {
                Debug.Log("Picking up " + item.name);
                if (item.name == "ankh")
                {
                    if (isis.isDead)
                    {
                        PlayerControl.instance.resurrectThisPlayer(isis);
                    }
                    else if (horus.isDead)
                    {
                        PlayerControl.instance.resurrectThisPlayer(horus);
                    }
                    else if (anubis.isDead)
                    {
                        PlayerControl.instance.resurrectThisPlayer(anubis);
                    }
                    else
                    {
                        Inventory.instance.AddItem(item);
                    }
                    Destroy(gameObject);
                }
                else
                {
                    if(item.canPickup)
                    {
                        Inventory.instance.AddItem(item);
                        Destroy(gameObject);
                    } else
                    {
                        Debug.Log("Didn't pass the guardian!");
                    }
                   
                }
                
            }
            
        }
    }
}
