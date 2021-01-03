﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{    
    public string playerName;
    public int maxHealth;
    protected int currentHealth;
    public string bestSkill;
    public Dictionary<string, int> skills;
    public bool isActive;
    public bool isDead;

    public Player()
    {
        playerName = "player";
        maxHealth = 100;
        currentHealth = maxHealth;
        bestSkill = "none";
        isDead = false;

        skills = new Dictionary<string, int>();
        skills.Add("strength", 0);
        skills.Add("charisma", 0);
        skills.Add("intelligence", 0);
        skills.Add("perception", 0);
        skills.Add("endurance", 0);
    }

    public void decreaseHealth(int healthValue)
    {
        currentHealth -= healthValue;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void setHealth(int healthToSet)
    {
        currentHealth = healthToSet;
    }

    public void setPrimaryPlayerCharacteristics()
    {
        transform.localPosition = new Vector3(0, 0, 1);
        transform.localScale = new Vector3(0.5f, 0.5f, transform.localScale.z);
    }

    public void setSecondaryPlayerCharacteristics(float x)
    {
        transform.localPosition = new Vector3(x, 2, 1);
        transform.localScale = new Vector3(0.3f, 0.3f, transform.localScale.z);
    }

    public static string KeyByValue(Dictionary<string, int> dictionary, int val)
    {
        string key = default;
        foreach (KeyValuePair<string, int> pair in dictionary)
        {
            if (pair.Value == val)
            {
                key = pair.Key;
                break;
            }
        }
        return key;
    }

}