using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector2 lastCheckpoitPos;
    public Dictionary<string, bool> answers = new Dictionary<string, bool>();
    public float contactDistance = 10f;
    public bool hasAllAnswers = false;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        answers.Add("wine", false);
        answers.Add("diary", false);
        answers.Add("stone", false);
        answers.Add("clock", false);

        lastCheckpoitPos = new Vector2(-7, 2);
    }

    void Update()
    {
        if (PlayerControl.instance.currentPlayer.getCurrentHealth() <= 0)
        {
            PlayerControl.instance.die();
        }

        win();
    }

    void win()
    {
        if(answers["wine"] == true && answers["diary"] == true && answers["stone"] == true && answers["clock"] == true)
        {
            //SceneManager.LoadScene("Win");
            hasAllAnswers = true;
        }
    }

    public bool checkPlayerProximityToObject(GameObject objectToCheck)
    {
        bool isClose = false;

        if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, objectToCheck.transform.position) < contactDistance)
        {
            isClose = true;
        }

        return isClose;
    }
}
