using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Horus : Player
{
    public Horus()
    {
        playerName = "Horus";
        skills["strength"] = 12;
        skills["charisma"] = 8;
        skills["intelligence"] = 14;
        skills["perception"] = 15;
        skills["endurance"] = 10;
        bestSkill = KeyByValue(skills, skills.Values.Max());
        maxHealth = 100;
        isDead = false;
        currentHealth = maxHealth;
        type = "Horus";
    }

    private void Update()
    {
        if (isDead)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
}
