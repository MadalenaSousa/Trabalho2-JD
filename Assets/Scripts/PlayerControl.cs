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
    public Isis isis;
    public Horus horus;
    public Anubis anubis;

    bool isFacingRight = true;

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
        Debug.Log("Player died!");
    }
}
