using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Isis : Player
{
    public Button isisButton;

    public Isis()
    {
        //DEFINE ISIS TRAITS
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
        //type = "Isis";
    }

    private void Update()
    {
        //Switch to ghost mode if dead
        if (isDead)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            isisButton.interactable = false;
        } else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            isisButton.interactable = true;
        }
    }

}