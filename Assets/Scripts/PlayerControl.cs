using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D body;
    private float moveInputX, moveInputY;
    public float speed = 5f;

    public GameObject[] players = new GameObject[3];
    GameObject currentPlayer;

    bool isFacingRight = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        players[0].GetComponent<Character1Skills>().enabled = true;
        players[1].GetComponent<Character2Skills>().enabled = false;
        players[2].GetComponent<Character3Skills>().enabled = false;
        currentPlayer = players[0];
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

            for(int i = 0; i < 3; i++)
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

            for (int i = 0; i < 3; i++)
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

            for (int i = 0; i < 3; i++)
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

            for (int i = 0; i < 3; i++)
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

    public void SwitchPlayer(int playerNum)
    {
        GameObject prevPlayer = currentPlayer;

        prevPlayer.transform.position = GameObject.FindGameObjectWithTag("Player" + playerNum).transform.position;
        prevPlayer.transform.localScale = GameObject.FindGameObjectWithTag("Player" + playerNum).transform.localScale;

        currentPlayer = players[playerNum - 1];
        currentPlayer.transform.position = new Vector3(transform.position.x, transform.position.y, currentPlayer.transform.position.z);
        currentPlayer.transform.localScale = new Vector3(0.5f, 0.5f, currentPlayer.transform.localScale.z);

        if(playerNum == 1)
        {
            players[0].GetComponent<Character1Skills>().enabled = true;
            players[1].GetComponent<Character2Skills>().enabled = false;
            players[2].GetComponent<Character3Skills>().enabled = false;
        }
        else if(playerNum == 2)
        {
            players[1].GetComponent<Character2Skills>().enabled = true;
            players[0].GetComponent<Character1Skills>().enabled = false;
            players[2].GetComponent<Character3Skills>().enabled = false;
        } 
        else if(playerNum == 3)
        {
            players[2].GetComponent<Character3Skills>().enabled = true;
            players[0].GetComponent<Character1Skills>().enabled = false;
            players[1].GetComponent<Character2Skills>().enabled = false;
        }
    }
}
