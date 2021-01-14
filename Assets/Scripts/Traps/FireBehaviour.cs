using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public float fireInterval = 1f;
    public float startTime = 0;
    GameObject fire;
    bool switchState;

    void Start()
    {
        fire = gameObject.transform.GetChild(0).gameObject;
        fire.SetActive(false);
        switchState = false;
    }

    
    void Update()
    {
        if (Time.timeSinceLevelLoad > startTime)
        {
            startTime = Time.timeSinceLevelLoad + fireInterval;

            switchState = !switchState;
        }

        if(switchState)
        {
            fire.SetActive(true);
        } 
        else
        {
            fire.SetActive(false);
        }
    }
}

