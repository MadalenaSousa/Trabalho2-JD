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

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        SwitchToPlayer1();
    }

    void FixedUpdate()
    {
        moveInputX = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");
        body.velocity = new Vector2(moveInputX * speed, moveInputY * speed);
    }

    public void SwitchToPlayer1()
    {
        currentPlayer = players[0];
        players[0].GetComponent<Character1Skills>().enabled = true;
        players[1].GetComponent<Character2Skills>().enabled = false;
        players[2].GetComponent<Character3Skills>().enabled = false;
    }

    public void SwitchToPlayer2()
    {
        currentPlayer = players[1];
        players[1].GetComponent<Character2Skills>().enabled = true;
        players[0].GetComponent<Character1Skills>().enabled = false;
        players[2].GetComponent<Character3Skills>().enabled = false;
    }

    public void SwitchToPlayer3()
    {
        currentPlayer = players[2];
        players[2].GetComponent<Character3Skills>().enabled = true;
        players[0].GetComponent<Character1Skills>().enabled = false;
        players[1].GetComponent<Character2Skills>().enabled = false;
    }
}
