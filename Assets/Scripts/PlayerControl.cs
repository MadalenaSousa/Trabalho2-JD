using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;

    private Rigidbody2D body;
    private float moveInputX, moveInputY;
    public float speed = 5f;

    public Player currentPlayer;
    public Player isis, horus, anubis;

    bool isFacingRight = true;
    Player deadPlayer;
    Player thirdPlayer;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        deadPlayer = null;

        body = GetComponent<Rigidbody2D>();

        isis = isis.GetComponent<Isis>();
        horus = horus.GetComponent<Horus>();
        anubis = anubis.GetComponent<Anubis>();
        
        currentPlayer = isis;

        Debug.Log(1 % 3);
        Debug.Log(2 % 3);
        Debug.Log(3 % 3);
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

    private void OnTriggerEnter2D(Collider2D info)
    {
        if(deadPlayer != null)
        {
            if (info.tag == deadPlayer.tag && deadPlayer.isDead == true)
            {
                Debug.Log("Colidiu com: " + deadPlayer + ", which as a tag of " + deadPlayer.tag);
                deadPlayer.transform.parent = gameObject.transform;
                deadPlayer.transform.localPosition = new Vector3(-thirdPlayer.transform.localPosition.x, 2f, currentPlayer.transform.localPosition.z);
                deadPlayer.transform.localScale = new Vector3(0.3f, 0.3f, currentPlayer.transform.localScale.z);
                deadPlayer.isDead = false;
                Debug.Log(isis.isDead);
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
        Player prevPlayer = currentPlayer;
        currentPlayer = newPlayer;

        prevPlayer.transform.position = GameObject.FindGameObjectWithTag(newPlayer.tag).transform.position;
        prevPlayer.transform.localScale = GameObject.FindGameObjectWithTag(newPlayer.tag).transform.localScale;

        currentPlayer.transform.position = new Vector3(transform.position.x, transform.position.y, currentPlayer.transform.position.z);
        currentPlayer.transform.localScale = new Vector3(0.5f, 0.5f, currentPlayer.transform.localScale.z);
    }

    public void die()
    {
        deadPlayer = currentPlayer;
        currentPlayer.transform.position = GameManager.instance.lastCheckpoitPos;
        currentPlayer.isDead = true;
        currentPlayer.transform.parent = null;

        Player[] players = new Player[3];
        players[0] = isis;
        players[1] = horus;
        players[2] = anubis;

        for(int i = 0; i < players.Length; i++)
        {
            if(players[i].isDead == false)
            {
                currentPlayer = players[i];
                thirdPlayer = players[(i + 1) % 3];
                currentPlayer.setPrimaryPlayerCharacteristics();
                currentPlayer.transform.parent = gameObject.transform;
                break;
            }
        }

        currentPlayer.setHealth((int)currentPlayer.maxHealth / 2);
    }
}
