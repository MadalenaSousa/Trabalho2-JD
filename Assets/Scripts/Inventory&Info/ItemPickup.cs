using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    Isis isis;
    Horus horus;
    Anubis anubis;
    Sprite normalSprite;
    public Sprite glowSprite;

    private void Start()
    {
        isis = PlayerControl.instance.isis;
        horus = PlayerControl.instance.horus;
        anubis = PlayerControl.instance.anubis;

        normalSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    private void Update()
    {
        if(GameManager.instance.checkPlayerProximityToObject(gameObject))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = glowSprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
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
                        //Animação de ressuscitar
                        //Info acerca do número de vidas que ainda tem
                        PlayerControl.instance.resurrectThisPlayer(isis);
                    }
                    else if (horus.isDead)
                    {
                        //Animação de ressuscitar
                        //Info acerca do número de vidas que ainda tem
                        PlayerControl.instance.resurrectThisPlayer(horus);
                    }
                    else if (anubis.isDead)
                    {
                        //Animação de ressuscitar
                        //Info acerca do número de vidas que ainda tem
                        PlayerControl.instance.resurrectThisPlayer(anubis);
                    }
                    else
                    {
                        //Animação do inventário
                        Inventory.instance.AddItem(item);
                    }
                    Destroy(gameObject);
                }
                else
                {
                    if(item.canPickup)
                    {
                        Inventory.instance.AddItem(item);
                        //Activate Panel
                        //Inventory Animation
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
