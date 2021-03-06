﻿using System.Collections;
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

    private string pathToPickUpSound = "pickingUpItem";
    private AudioClip pickUpItemClip;

    private void Start()
    {
        isis = PlayerControl.instance.isis;
        horus = PlayerControl.instance.horus;
        anubis = PlayerControl.instance.anubis;

        normalSprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        objectDetailPanel.SetActive(false); ;

        pickUpItemClip = Resources.Load<AudioClip>(pathToPickUpSound);

        if (item.name == "ankh")
        {
            item.canPickup = true;
        } 
        else
        {
            item.canPickup = false;
        }

        // item.pickUpAudioSource = new AudioSource;
        item.pickUpAudioClip = pickUpItemClip;
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().playOnAwake = false;
        gameObject.GetComponent<AudioSource>().clip = item.pickUpAudioClip;
    }

    private void Update()
    {
        //Switch to glow sprite if player is in click range
        if(GameManager.instance.checkPlayerProximityToObject(gameObject) && item.canPickup)
        {
            //gameObject.GetComponent<SpriteRenderer>().sprite = glowSprite;
            gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        }
        else
        {
            //gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
            gameObject.transform.localScale = new Vector3(1, 1, 0);
        }

        //Change item color if item is pickable
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

                    AudioSource resurectSoundSource = PlayerControl.instance.GetComponent<AudioSource>();
                    //THE ITEM IS AN ANKH
                    if (isis.isDead)
                    {
                        resurectSoundSource.Play();
                        panelText.text = "You resurrected Isis! Carefull, you have " + getNumOfLifes().ToString() + " lifes available and you need all players alive to pass the level!";
                        PlayerControl.instance.resurrectThisPlayer(isis);
                    }
                    else if (horus.isDead)
                    {
                        resurectSoundSource.Play();
                        panelText.text = "You resurrected Horus! Carefull, you have " + getNumOfLifes().ToString() + " lifes available and you need all players alive to pass the level!";
                        PlayerControl.instance.resurrectThisPlayer(horus);
                    }
                    else if (anubis.isDead)
                    {
                        resurectSoundSource.Play();
                        panelText.text = "You resurrected Anubis! Carefull, you have " + getNumOfLifes().ToString() + " lifes available and you need all players alive to pass the level!";
                        PlayerControl.instance.resurrectThisPlayer(anubis);
                    }
                    else
                    {        
                        AudioSource.PlayClipAtPoint(item.pickUpAudioClip, transform.position);
                        panelText.text = objectDescription;
                        Inventory.instance.AddItem(item);
                    }
                    objectDetailPanel.SetActive(true);
                    Destroy(gameObject);
                }
                else
                {
                    //ITEM IS AN ENIGMA ANSWER
                    if(item.canPickup)
                    {
                        AudioSource.PlayClipAtPoint(item.pickUpAudioClip, transform.position);

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
