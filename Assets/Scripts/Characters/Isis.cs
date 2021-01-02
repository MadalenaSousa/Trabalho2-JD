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
    }
}