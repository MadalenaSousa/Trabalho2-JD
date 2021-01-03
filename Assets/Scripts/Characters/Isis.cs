using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Isis : Player
{
    public Isis()
    {
        playerName = "Isis";
        skills["strength"] = 8;
        skills["charisma"] = 15;
        skills["intelligence"] = 14;
        skills["perception"] = 12;
        skills["endurance"] = 10;
        bestSkill = KeyByValue(skills, skills.Values.Max());
        maxHealth = 72;
        isDead = false;
        currentHealth = maxHealth;
        type = "Isis";
    }

    private void Update()
    {
        if(isDead)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        } else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

}