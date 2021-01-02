using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector2 lastCheckpoitPos;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        lastCheckpoitPos = new Vector2(-7, 2);
    }

    void Update()
    {
        if (PlayerControl.instance.currentPlayer.getHealth() <= 0)
        {
            //PlayerControl.instance.die();
        }
    }
}
