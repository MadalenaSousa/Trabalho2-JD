using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Horus : Player
{
    private void Start()
    {
        isActive = false;
        //Debug.Log(gameObject.transform.localPosition);
    }

    public Horus()
    {
        playerName = "Horus";
        skills["strength"] = 12;
        skills["charisma"] = 8;
        skills["intelligence"] = 14;
        skills["perception"] = 15;
        skills["endurance"] = 10;
        bestSkill = KeyByValue(skills, skills.Values.Max());
    }

  
}
