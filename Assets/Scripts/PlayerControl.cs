using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public GameObject warningPanel;

    public Animator isisAnimator, horusAnimator, anubisAnimator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        isis = GetComponentInChildren<Isis>();
        horus = GetComponentInChildren<Horus>();
        anubis = GetComponentInChildren<Anubis>();

        isisAnimator = isis.GetComponent<Animator>();
        horusAnimator = horus.GetComponent<Animator>();
        anubisAnimator = anubis.GetComponent<Animator>();

        currentPlayer = isis;

        inventory = Inventory.instance;
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //MOVE PLAYERS
        moveInputX = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");
        body.velocity = new Vector2(moveInputX * speed, moveInputY * speed);

        //TURN PLAYERS
        if(isFacingRight && moveInputX < 0)
        {
            FlipHorizontal();
        } else if(isFacingRight == false && moveInputX > 0)
        {
            FlipHorizontal();
        }

        Debug.Log(moveInputY);
        isisAnimator.SetFloat("ySpeed", moveInputY);
        isisAnimator.SetFloat("xSpeed", Mathf.Abs(moveInputX));

        horusAnimator.SetFloat("ySpeed", moveInputY);
        horusAnimator.SetFloat("xSpeed", Mathf.Abs(moveInputX));

        anubisAnimator.SetFloat("ySpeed", moveInputY);
        anubisAnimator.SetFloat("xSpeed", Mathf.Abs(moveInputX));

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
            isis.isDead = false;
        } else if(currentPlayer == horus)
        {
            horus.setPrimaryPlayerCharacteristics();
            isis.setSecondaryPlayerCharacteristics(0.5f);
            anubis.setSecondaryPlayerCharacteristics(-0.5f);
            horus.isDead = false;
        }
        else if (currentPlayer == anubis)
        {
            anubis.setPrimaryPlayerCharacteristics();
            isis.setSecondaryPlayerCharacteristics(0.5f);
            horus.setSecondaryPlayerCharacteristics(-0.5f);
            anubis.isDead = false;
        }
    }

    public void die()
    {
        int numberOfAnkhs = GameObject.FindGameObjectsWithTag("Life").Length;
        int leftOverAnkhs = numberOfAnkhs - 1;
        
        if(numberOfAnkhs == 0)
        {
            leftOverAnkhs = 0;
        }

        if (checkAndUseItem("ankh")) //If there's a ankh in invetory -> use it
        {
            warningPanel.SetActive(true);
            warningPanel.GetComponentInChildren<Text>().text = "Oh no! Your character just died! Thank god you had an ankh on your Inventory! Be carefull, you now only have " + leftOverAnkhs + " ankhs available and you need all players alive to pass this level!";
            currentPlayer.setHealth(currentPlayer.getMaxHealth());
            GetComponent<AudioSource>().Play();
        } 
        else
        {
            killThisPlayer(currentPlayer);
            if (getNextLivingPlayer() == null || numberOfAnkhs < numberOfDeadPlayers()) //lose conditions
            {
                //Lose sound
                SceneManager.LoadScene("Lose");
            }
            else //switch to a living player
            {
                warningPanel.SetActive(true);
                warningPanel.GetComponentInChildren<Text>().text = "Oh no! Your character just died! You need to find an ankh to ressurrect it! Be carefull, you now only have " + numberOfAnkhs + " ankhs available and you need all players alive to pass this level!";
                SwitchPlayer(getNextLivingPlayer());
                //resurrectThisPlayer(currentPlayer);
            }
        }

        //Reposition players in last checkpoint
        transform.position = new Vector3(GameManager.instance.lastCheckpoitPos.x, GameManager.instance.lastCheckpoitPos.y, PlayerControl.instance.transform.position.z);
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
                //specific character death sound
                playerToKill.GetComponent<AudioSource>().Play();
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
                players[i].setHealth(players[i].getMaxHealth()); //Should we set it to their specific max health or to the absolute max health?
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

    public Player checkCurrentPlayerSubClass()
    {
        Player[] players = new Player[3];
        players[0] = isis;
        players[1] = horus;
        players[2] = anubis;

        Player currentPlayerSubClass = players[0];

        for(int i = 0; i < players.Length; i++)
        {
            if(currentPlayer == players[i])
            {
                currentPlayerSubClass = players[i];
            }
        }

        return currentPlayerSubClass;
    }

    public bool checkIfAllPlayersAreAlive()
    {
        bool areAllAlive = true;

        Player[] players = new Player[3];
        players[0] = isis;
        players[1] = horus;
        players[2] = anubis;

        if(isis.isDead || anubis.isDead || horus.isDead)
        {
            areAllAlive = false;
        }

        return areAllAlive;
    }
}
