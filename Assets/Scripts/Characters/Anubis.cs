﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Anubis : Player
{
    public Button anubisButton;

    public Anubis()
    {
        //DEFINE ANUBIS TRAITS
        playerName = "Anubis";

        skills["strength"] = 15;
        skills["charisma"] = 10;
        skills["intelligence"] = 12;
        skills["perception"] = 8;
        skills["endurance"] = 14;

        bestSkill = KeyByValue(skills, skills.Values.Max());

        maxHealth = 100;
        isDead = false;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //Switch to ghost mode if dead
        if (isDead)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            anubisButton.interactable = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            anubisButton.interactable = true;
        }
    }

}
