﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;

    private Rigidbody2D body;
    private float moveInputX, moveInputY;
    public float speed = 5f;

    public Player currentPlayer;
    public Isis isis;
    public Horus horus;
    public Anubis anubis;

    bool isFacingRight = true;

    Inventory inventory;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        isis = GetComponentInChildren<Isis>();
        horus = GetComponentInChildren<Horus>();
        anubis = GetComponentInChildren<Anubis>();

        currentPlayer = isis;

        inventory = Inventory.instance;
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInputX = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");
        body.velocity = new Vector2(moveInputX * speed, moveInputY * speed);

        if(isFacingRight && moveInputX < 0)
        {
            FlipHorizontal();
        } else if(isFacingRight == false && moveInputX > 0)
        {
            FlipHorizontal();
        }

        if (moveInputX < 0)
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                -90f);

            for(int i = 0; i < gameObject.transform.childCount; i++)
            {
                transform.GetChild(i).transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    0f);
            }
                
        }
        else if (moveInputX > 0)
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                90f);

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                transform.GetChild(i).transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    0f);
            }
        } 
        else if (moveInputY < 0)
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                0f);

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                transform.GetChild(i).transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    0f);
            }
        } 
        else if(moveInputY > 0)
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                180f);

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                transform.GetChild(i).transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    0f);
            }
        }
    }

    public void FlipHorizontal()
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale; //get scale
        Scaler.x *= -1; //flip it
        transform.localScale = Scaler;
    }

    public void SwitchPlayer(Player newPlayer)
    {
        currentPlayer = newPlayer;

        if(currentPlayer == isis)
        {
            isis.setPrimaryPlayerCharacteristics();
            horus.setSecondaryPlayerCharacteristics(0.5f);
            anubis.setSecondaryPlayerCharacteristics(-0.5f);
        } else if(currentPlayer == horus)
        {
            horus.setPrimaryPlayerCharacteristics();
            isis.setSecondaryPlayerCharacteristics(0.5f);
            anubis.setSecondaryPlayerCharacteristics(-0.5f);
        }
        else if (currentPlayer == anubis)
        {
            anubis.setPrimaryPlayerCharacteristics();
            isis.setSecondaryPlayerCharacteristics(0.5f);
            horus.setSecondaryPlayerCharacteristics(-0.5f);
        }
    }

    public void die()
    {
        int numberOfAnkhs = GameObject.FindGameObjectsWithTag("Life").Length;

        if (checkAndUseItem("ankh"))
        {
            currentPlayer.setHealth(currentPlayer.getMaxHealth());
        } 
        else
        {
            killThisPlayer(currentPlayer);
            if (getNextLivingPlayer() == null || numberOfAnkhs < numberOfDeadPlayers())
            {
                SceneManager.LoadScene("Lose");
            }
            else
            {
                SwitchPlayer(getNextLivingPlayer());
                resurrectThisPlayer(currentPlayer);
            }
        }
     
    }

    public void killThisPlayer(Player playerToKill)
    {
        Player[] players = new Player[3];
        players[0] = isis;
        players[1] = horus;
        players[2] = anubis;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == playerToKill)
            {
                players[i].isDead = true;
            }
        }
    }

    public void resurrectThisPlayer(Player playerToResurrect)
    {
        Player[] players = new Player[3];
        players[0] = isis;
        players[1] = horus;
        players[2] = anubis;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == playerToResurrect)
            {
                players[i].isDead = false;
            }
        }
    }

    public int numberOfDeadPlayers()
    {
        Player[] players = new Player[3];
        players[0] = isis;
        players[1] = horus;
        players[2] = anubis;

        int count = 0;

        for (int i = 0; i < players.Length; i++)
        {
            if(players[i].isDead)
            {
                count++;
            }
        }

        return count;
    }

    public Player getNextLivingPlayer()
    {
        Player[] players = new Player[3];
        players[0] = isis;
        players[1] = horus;
        players[2] = anubis;

        Player nextP = null;

        for (int i = 0; i < 3; i++)
        {
            if (players[i].isDead == false)
            {
                nextP = players[i];
            } 
        }

        return nextP;
    }

    public bool checkAndUseItem(string itemName)
    {
        bool exists = false;

        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.items[i].name == itemName)
            {
                inventory.RemoveItem(inventory.items[i]);
                exists = true;
            }
        }

        return exists;
    }
}
