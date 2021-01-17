using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    Isis isis;
    Horus horus;
    Anubis anubis;
    Sprite normalSprite;
    public Sprite glowSprite;

    public GameObject objectDetailPanel;
    public Image panelImage;
    public Text panelText;
    public Sprite objectImage;
    [TextArea(2, 10)]
    public string objectDescription;

    private void Start()
    {
        isis = PlayerControl.instance.isis;
        horus = PlayerControl.instance.horus;
        anubis = PlayerControl.instance.anubis;

        normalSprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        objectDetailPanel.SetActive(false); ;

        if(item.name == "ankh")
        {
            item.canPickup = true;
        } 
        else
        {
            item.canPickup = false;
        }
    }

    private void Update()
    {
        if(GameManager.instance.checkPlayerProximityToObject(gameObject) && item.canPickup)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = glowSprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
        }

        if(!item.canPickup)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
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
                    int numOfLifes = GameObject.FindGameObjectsWithTag("Life").Length;
                    if (isis.isDead)
                    {
                        //Som de ressuscitar
                        panelText.text = "You found and Ankh! This will ressurrect Isis! But be carefull, now you have " + getNumOfLifes().ToString() + " lifes available and you need to have all players alive to pass this level!";
                        PlayerControl.instance.resurrectThisPlayer(isis);
                    }
                    else if (horus.isDead)
                    {
                        //Som de ressuscitar
                        panelText.text = "You found and Ankh! This will ressurrect Horus! But be carefull, now you have " + getNumOfLifes().ToString() + " lifes available and you need to have all players alive to pass this level!";
                        PlayerControl.instance.resurrectThisPlayer(horus);
                    }
                    else if (anubis.isDead)
                    {
                        //Som de ressuscitar
                        panelText.text = "You found and Ankh! This will ressurrect Anubis! But be carefull, now you have " + getNumOfLifes().ToString() + " lifes available and you need to have all players alive to pass this level!";
                        PlayerControl.instance.resurrectThisPlayer(anubis);
                    }
                    else
                    {
                        //Som de Adicionar ao Inventário?
                        panelText.text = objectDescription;
                        Inventory.instance.AddItem(item);
                    }
                    objectDetailPanel.SetActive(true);
                    Destroy(gameObject);
                }
                else
                {
                    if(item.canPickup)
                    {
                        objectDetailPanel.SetActive(true);
                        Inventory.instance.AddItem(item);
                        panelImage.sprite = objectImage;
                        panelText.text = objectDescription;
                        Destroy(gameObject);
                    } else
                    {
                        Debug.Log("Didn't pass the guardian!");
                    }
                   
                }
                
            }
            
        }
    }

    public int getNumOfLifes()
    {
        int numOfLifes = GameObject.FindGameObjectsWithTag("Life").Length;
        int leftOverLifes = numOfLifes - 1; ;

        if(numOfLifes == 0)
        {
            leftOverLifes = 0;
        }

        return leftOverLifes;
    }
}
